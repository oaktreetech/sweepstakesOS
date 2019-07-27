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

namespace SweepstakesOS
{
    public enum FileType
    {
        CSV,
        XLS
    }

    public partial class frmMultiplyEntries : Form
    {
        public frmMultiplyEntries()
        {
            InitializeComponent();

        }

        private void PopulateFields(string filepath)
        {
            #region Populate Field Names

            List<string> field_names = new List<string>();

            switch(ucEntryFileOpenControl1.FileType)
            {
                case FileType.CSV:
                    field_names = ReadCSV(filepath);
                    break;
                case FileType.XLS:
                    field_names = ReadXLS(filepath);
                    break;
                default:
                    break;
            }

            comboBox1.DataSource = field_names;
            comboBox1.SelectedIndex = -1;

            #endregion
        }

        private List<string> ReadCSV(string filepath)
        {
            string[] field_names = new string[1];

            using(StreamReader reader = new StreamReader(filepath))
            {
                string first_line = reader.ReadLine();
                field_names = first_line.Split(',');
            }

            return field_names.ToList<string>();
        }

        private string WriteCSV(string filepath, string field_to_multiply)
        {
            string input_file = filepath;
            string output_file = Path.GetDirectoryName(input_file)
                + @"\" + Path.GetFileNameWithoutExtension(input_file) + "_multiply"
                + Path.GetExtension(input_file);

            if(!File.Exists(input_file))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            int lines_written = 0;
            using(StreamReader input_reader = new StreamReader(input_file))
            using(StreamWriter output_writer = new StreamWriter(output_file,false))
            {
                //Copy Headers
                output_writer.WriteLine(input_reader.ReadLine());
                lines_written++;

                //Multiply Out
                string line = "";
                while((line = input_reader.ReadLine()) != null)
                {
                    //Get Number of times to repeat
                    int number = 1;

                    //Remove "\"" and enclosed ','
                    if(line.Contains("\""))
                    {
                        int start = line.IndexOf("\"");
                        int end = line.IndexOf("\"", start + 1);
                        string enclosed = line.Substring(start + 1, end - start - 1);
                        string new_enclosed = enclosed.Replace(",", " ");
                        line = line.Replace(enclosed, new_enclosed);
                    }

                    line = line.Replace("\"","");

                    try
                    {
                        number = int.Parse(line.Split(',')[comboBox1.SelectedIndex]);
                    }
                    catch(Exception exc)
                    {
                        continue;
                    }


                    //Perform repeat writes
                    for(int i = 0; i < number; i++)
                    {
                        output_writer.WriteLine(line);
                        lines_written++;
                    }
                }
            }

            MessageBox.Show(lines_written + " lines written.");

            return output_file;
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

        private string WriteXLS(string filepath, string field_to_multiply)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string output_file = "";
            switch(ucEntryFileOpenControl1.FileType)
            {
                case FileType.CSV:
                    output_file = WriteCSV(ucEntryFileOpenControl1.FilePath, comboBox1.SelectedItem.ToString());
                    break;
                case FileType.XLS:
                    output_file = WriteXLS(ucEntryFileOpenControl1.FilePath, comboBox1.SelectedItem.ToString());
                    break;
                default:
                    break;
            }

            Process.Start(output_file);
        }

        private void newFileSelected(object sender, EventArgs e)
        {
            PopulateFields(ucEntryFileOpenControl1.FilePath);
        }

        private void videoHelp_Click(object sender, EventArgs e)
        {
            //Video Play
        }
    
    }
}
