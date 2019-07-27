using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace SweepstakesOS
{
    public partial class ucEntryFileOpenControl : UserControl
    {
        public event EventHandler NewFileSelected;

        private string m_output_name = "temp";

        public FileType FileType { get; set; }
        public string FilePath { get; set; }

        [Browsable(true)]
        public string OutputName
        {
            get
            {
                return m_output_name;
            }
            set
            {
                m_output_name = value;
            }
        }

        [Browsable(true)]
        public string LabelText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public ucEntryFileOpenControl()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Spreadsheet Files (*.csv, *.xls*)|*.csv;*.xls*";
        }

        private void cmdOpenDialog_Click(object sender, EventArgs e)
        {

            if(openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName;
                txtFilename.Text = Path.GetFileName(FilePath);

                #region Get Extension and FileType

                string extension = Path.GetExtension(FilePath);
                List<string> field_names = new List<string>();

                switch(extension)
                {
                    case ".csv":
                        FileType = SweepstakesOS.FileType.CSV;
                        break;
                    case ".xls":
                    case ".xlsx":
                        FileType = SweepstakesOS.FileType.CSV;
                        FilePath = SaveAsCSV(FilePath);
                        break;
                    default:
                        break;
                }

                #endregion

                OnNewFileSelected(new EventArgs());
            }
        }

        private string SaveAsCSV(string path)
        {
            object m = Type.Missing;
            string directory = Path.GetDirectoryName(path);
            string new_file = directory + @"\" + m_output_name + ".csv";

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(path);
            Excel.Worksheet ws = (Worksheet)wb.ActiveSheet;
            ws.Unprotect(m);
            Range r = ws.UsedRange;

            //Remove Line Feeds within Excel
            //bool success = (bool)r.Replace(
            //    "\n",
            //    "",
            //    XlLookAt.xlWhole,
            //    XlSearchOrder.xlByRows,
            //    true, m, m, m);

            wb.SaveAs(new_file, Excel.XlFileFormat.xlCSVWindows);
            wb.Close(false);
            app.Quit();

            return new_file;
        }

        protected virtual void OnNewFileSelected(EventArgs e)
        {
            if(NewFileSelected != null)
                NewFileSelected(this, e);
        }
    }
}
