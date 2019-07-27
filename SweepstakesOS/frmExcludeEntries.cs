using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace SweepstakesOS
{
    public partial class frmExcludeEntries : Form
    {
        public frmExcludeEntries()
        {
            InitializeComponent();
        }
        
        private List<string> ReadXLS(string filepath)
        {
            throw new NotImplementedException();
            /*
            List<string> headers = new List<string>();

            Excel.Workbook wbExcel = null;
            Excel.Worksheet oSheet;
            Excel.Range oRange;

            Excel.Application oExcel = new Excel.Application();

            try
            {
                wbExcel = oExcel.Workbooks.Open(filepath);
                oSheet = wbExcel.Worksheets[1];
                oRange = (Excel.Range)oSheet.UsedRange;
                oRange = (Excel.Range)oRange.Rows[1];
                //var oHeaders = oRange.Value2[1, oRange.Columns.Count];
                //oRange = (Excel.Range)oRange.Range[1, oRange.Columns.Count];
                //oRange = (Excel.Range)oRange.Cells["A1", "A100"];

                for(int i = 1; i <= oRange.Columns.Count; i++ )
                {
                    headers.Add((string)oRange.Value2[1, i]);
                }

                //foreach(object o in oRange)
                //{
                //    Excel.Range r = o as Excel.Range;
                //    string s = (string)r.Value2;
                //    if(s == null || string.IsNullOrWhiteSpace((string)s))
                //        break;

                //    headers.Add((string)s);
                //}


            }
            catch(Exception exc)
            {
                MessageBox.Show("Error reading Excel file.\n\n" + exc.ToString());
            }
            finally
            {
                //if(wbExcel != null)
                //    wbExcel.Close();
            }

            return headers;
             */
        }

        private void ucOriginal_NewFileSelected(object sender, EventArgs e)
        {
            string filepath = ucOriginal.FilePath;
            List<string> field_names = new List<string>();

            switch(ucOriginal.FileType)
            {
                case FileType.CSV:
                    field_names = FileOperations.ReadHeadersCSV(filepath);
                    //field_names = ReadCSV(filepath);
                    break;
                case FileType.XLS:
                    //field_names = ReadXLS(filepath);
                    break;
                default:
                    break;
            }

            cmbOriginal.DataSource = field_names;
            cmbOriginal.SelectedIndex = -1;
        }

        private void ucExclude_NewFileSelected(object sender, EventArgs e)
        {
            string filepath = ucExclude.FilePath;
            List<string> field_names = new List<string>();

            switch(ucExclude.FileType)
            {
                case FileType.CSV:
                    field_names = FileOperations.ReadHeadersCSV(filepath);
                    break;
                case FileType.XLS:
                    field_names = ReadXLS(filepath);
                    break;
                default:
                    break;
            }

            cmbExclude.DataSource = field_names;
            cmbExclude.SelectedIndex = -1;
        }

        private void cmdExclude_Click(object sender, EventArgs e)
        {
            if(ucExclude.FileType != ucOriginal.FileType)
                throw new Exception("FileTypes must be the same.\n\nBoth CSV or Both XLSX");

            string output_file = "";
            switch(ucOriginal.FileType)
            {
                case FileType.CSV:
                    output_file = FileOperations.WriteCSV(ucOriginal.FilePath, ucExclude.FilePath, cmbOriginal.SelectedIndex, cmbExclude.SelectedIndex);
                    //output_file = WriteCSV(ucOriginal.FilePath, ucExclude.FilePath, cmbOriginal.SelectedIndex, cmbExclude.SelectedIndex);
                    break;
                case FileType.XLS:
                    //output_file = WriteXLS(ucEntryFileOpenControl1.FilePath, comboBox1.SelectedItem.ToString());
                    break;
                default:
                    break;
            }

            Process.Start(output_file);
        }

        //private string WriteCSV(string filepath_original, string filepath_exclude, int column_original, int column_exclude)
        //{
        //    //SaveAsCSV(filepath_original, "temp_original");
        //    //SaveAsCSV(filepath_exclude, "temp_exclude");

        //    #region Fill Exclude Data To Match

        //    if(!File.Exists(filepath_exclude))
        //    {
        //        throw new FileNotFoundException("File does not exist.");
        //    }

        //    List<string> match_list = new List<string>();
        //    int lines_written = 0;
        //    using(StreamReader input_reader = new StreamReader(filepath_exclude))
        //    {
        //        string line;
        //        while((line = input_reader.ReadLine()) != null)
        //        {
        //            //Remove "\"" and enclosed ','
        //            if(line.Contains("\""))
        //            {
        //                int start = line.IndexOf("\"");
        //                int end = line.IndexOf("\"", start + 1);

        //                if(end < start)
        //                {

        //                }
        //                else
        //                {
        //                    string enclosed = line.Substring(start + 1, end - start - 1);
        //                    string new_enclosed = enclosed.Replace(",", " ");
        //                    line = line.Replace(enclosed, new_enclosed);
        //                }
        //            }

        //            //line = line.Replace("\n","");
        //            string[] fields = line.Split(',');
        //            match_list.Add(fields[column_exclude]);
        //        }
        //    }

        //    #endregion

        //    string input_file = filepath_original;
        //    string output_file = Path.GetDirectoryName(input_file)
        //        + @"\" + Path.GetFileNameWithoutExtension(input_file) + "_exclude"
        //        + Path.GetExtension(input_file);

        //    if(!File.Exists(input_file))
        //    {
        //        throw new FileNotFoundException("File does not exist.");
        //    }

        //    lines_written = 0;
        //    int excludes = 0;
        //    List<string> matches = new List<string>();
        //    using(StreamReader input_reader = new StreamReader(input_file))
        //    using(StreamWriter output_writer = new StreamWriter(output_file, false))
        //    {
        //        //Copy Headers
        //        output_writer.WriteLine(input_reader.ReadLine());
        //        lines_written++;

        //        //Exclude
        //        string line = "";
        //        while((line = input_reader.ReadLine()) != null)
        //        {
        //            //Remove "\"" and enclosed ','
        //            if(line.Contains("\""))
        //            {
        //                int start = line.IndexOf("\"");
        //                int end = line.IndexOf("\"", start + 1);

        //                if(end < start)
        //                {

        //                }
        //                else
        //                {
        //                    string enclosed = line.Substring(start + 1, end - start - 1);
        //                    string new_enclosed = enclosed.Replace(",", " ");
        //                    line = line.Replace(enclosed, new_enclosed);
        //                }
        //            }

        //            string[] fields = line.Split(',');

        //            if(!match_list.Contains(fields[column_original]))
        //            {
        //                //NO MATCH, write
        //                output_writer.WriteLine(line);
        //                lines_written++;
        //            }
        //            else
        //            {
        //                matches.Add(fields[column_original]);
        //                excludes++;
        //            }
        //        }
        //    }

        //    //Remove duplicates in matches
        //    matches = matches.Distinct().ToList();

        //    StringBuilder msg = new StringBuilder(lines_written + " lines written.\n\n" + excludes + " Excluded\n\n");
        //    foreach(string s in matches)
        //        msg.AppendLine(s);

        //    MessageBox.Show(msg.ToString());

        //    return output_file;
        //}

        //private string SaveAsCSV(string path, string output_filename)
        //{
        //    string directory = Path.GetDirectoryName(path);
        //    string new_file = directory + @"\" + output_filename + ".csv";

        //    Excel.Application app = new Excel.Application();
        //    Excel.Workbook wb = app.Workbooks.Open(path);
        //    wb.SaveAs(new_file, Excel.XlFileFormat.xlCSVWindows);
        //    wb.Close(false);
        //    app.Quit();

        //    return new_file;
        //}
    }
}
