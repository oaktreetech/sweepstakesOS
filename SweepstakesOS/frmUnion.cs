using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SweepstakesOS
{
    public partial class frmUnion : Form
    {
        string FilePath = @"C:\Users\Shawn\Documents\5) Oaktree\2) Sweepstakes\Projects\2) 2017\3) Gene Excel Union";

        public frmUnion()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Spreadsheet Files (*.csv, *.xls*)|*.csv;*.xls*";

            listBox1.DisplayMember = "FileName";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string FilePath = openFileDialog1.FileName;
                string FileName = Path.GetFileName(FilePath);

                #region Get Extension and FileType

                string extension = Path.GetExtension(FilePath);
                List<string> field_names = new List<string>();

                switch(extension)
                {
                    case ".csv":
                        //FileType = SweepstakesOS.FileType.CSV;
                        break;
                    case ".xls":
                    case ".xlsx":
                        //FileType = SweepstakesOS.FileType.CSV;
                        FilePath = FileOperations.SaveAsCSV(FilePath, FileName);
                        break;
                    default:
                        break;
                }

                #endregion

                listBox1.Items.Add(new FileStructure(FilePath));
                GetSharedHeaders();
            }
        }

        private void cmdUnion_Click(object sender, EventArgs e)
        {
            int N = 3; //Levenshtein Comparator Threshold
            LevenshteinDistanceStringComparer lev_comparator = new LevenshteinDistanceStringComparer(N);
            this.Cursor = Cursors.WaitCursor;

            if(lstHeaders.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a 'Shared Header' to perform the intersection on.");
                return;
            }

            string match_header = (string)lstHeaders.SelectedItem;
            List<FileStructure> files = listBox1.Items.Cast<FileStructure>().ToList();
            //List<string> headers = FileOperations.ReadHeadersCSV(files[0].FilePath);
            List<string> intersects = new List<string>();

            bool first_pass = true;
            foreach(FileStructure f_struct in files)
            {
                #region Retrieve data in column that matches header selected to intersect against
                
                //Get Index Match

                int index_header = 0;
                for(int i = 0; i < f_struct.Headers.Count; i++)
                {
                    FieldHeaderComparer comparer = new FieldHeaderComparer();

                    if(comparer.Equals(f_struct.Headers[i], match_header))
                    {
                        index_header = i;
                        break;
                    }
                }
                
                //Get Column Data From Matching Header
                List<string[]> entries = FileOperations.ReadCSV(f_struct.FilePath);
                List<string> data_column = new List<string>();
                foreach(string[] entry in entries)
                {
                    data_column.Add(entry[index_header].Trim());
                }
                                
                #endregion

                #region Perform Intersect Operation

                if(!first_pass)
                {
                    //1 -> 256 Matches
                    //2 -> 253 Matches
                    //3 -> 242 Matches
                    //4 -> 223 Matches
                    //5 -> 208 Matches
                    //6 -> 195 Matches
                    intersects = intersects.Intersect(data_column, lev_comparator).ToList();
                }
                else
                {
                    intersects = data_column;
                    first_pass = false;
                }

                #endregion

            }

            //Find Largest DB File

            FileStructure output_db = files.OrderByDescending(x => x.Filesize).First();

            //Match Intersects with rows in file
            List<string[]> input_entries = FileOperations.ReadCSV(output_db.FilePath);
            List<string[]> output_matches = new List<string[]>();

            int output_index_header = 0;
            for(int i = 0; i < output_db.Headers.Count; i++)
            {
                FieldHeaderComparer comparer = new FieldHeaderComparer();

                if(comparer.Equals(output_db.Headers[i], match_header))
                {
                    output_index_header = i;
                    break;
                }
            }

            foreach(string[] entry in input_entries)
            {
                bool is_match = false;
                foreach(string intersect_match in intersects)
                {
                    if(lev_comparator.Equals(entry[output_index_header], intersect_match))
                    {
                        is_match = true;
                        break;
                    }
                }

                if(is_match)
                    output_matches.Add(entry);
            }

            //Eliminate Empties and Duplicates

            List<string[]> output_matches_new = new List<string[]>();
            foreach(string[] entry in output_matches)
            {
                if(string.IsNullOrWhiteSpace(entry[output_index_header]))
                    continue;

                bool duplicate = false;
                foreach(string[] new_entry in output_matches_new)
                {
                    if(new_entry[output_index_header] == entry[output_index_header])
                    {
                        duplicate = true;
                        break;
                    }
                }

                if(!duplicate)
                    output_matches_new.Add(entry);
            }


            //Write Out

            using(StreamWriter writer = new StreamWriter(FilePath + "\\intersection.csv", false))
            {
                foreach(string[] entry in output_matches_new)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach(string field in entry)
                    {
                        builder.Append(field + ",");
                    }
                    //builder.Remove(builder.Length - 1, 1);
                    writer.WriteLine(builder.ToString());
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void cmdAddFolder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string FilePath = @"C:\Users\Shawn\Documents\5) Oaktree\2) Sweepstakes\Projects\2) 2017\3) Gene Excel Union";// folderBrowserDialog1.SelectedPath;
            bool convert_excel = chkConvert.Checked;

            //if(folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //{
            //string FileName = Path.GetFileName(FilePath);

            #region Convert Excel Files without Corresponding CSV

            if(convert_excel)
            {

                List<string> csv_files = Directory.GetFiles(FilePath, "*.csv", SearchOption.TopDirectoryOnly)
                    .ToList();
                csv_files.ForEach(s => Path.GetFileNameWithoutExtension(s));
                List<string> excel_files = Directory.GetFiles(FilePath, "*.xlsx", SearchOption.TopDirectoryOnly)
                    .ToList();

                for(int i = 0; i < excel_files.Count; i++)
                {
                    excel_files[i] = Path.GetFileNameWithoutExtension(excel_files[i]);
                }

                excel_files = excel_files.Where(s => !csv_files.Contains(s)).ToList();

                for(int i = 0; i < excel_files.Count; i++)
                {
                    excel_files[i] = FilePath + "\\" + excel_files[i] + ".xlsx";
                }

                foreach(string s in excel_files)
                {
                    FileOperations.SaveAsCSV(s, Path.GetFileNameWithoutExtension(s));
                }
            }
            #endregion

            List<string> files = Directory.GetFiles(FilePath, "*.csv", SearchOption.TopDirectoryOnly)
                    .ToList();

                #region Get Extension and FileType

                FileStructure file_struct = null;
                foreach(string file in files)
                {
                    string extension = Path.GetExtension(file);
                    string filename = Path.GetFileNameWithoutExtension(file);
                    string csvfile = file;
                    //If not CSV, convert
                    if(extension != ".csv")
                        csvfile = FileOperations.SaveAsCSV(file, filename);

                    List<string> field_names = new List<string>();
                    file_struct = new FileStructure(csvfile);

                    //switch(extension)
                    //{
                    //    case ".csv":
                    //        //FileType = SweepstakesOS.FileType.CSV;
                    //        break;
                    //    case ".xls":
                    //    case ".xlsx":
                    //        //FileType = SweepstakesOS.FileType.CSV;
                    //        //FilePath = FileOperations.SaveAsCSV(FilePath, file);
                    //        break;
                    //    default:
                    //        break;
                    //}
                    listBox1.Items.Add(file_struct);
                }

                #endregion

            //}
                GetSharedHeaders();
                this.Cursor = Cursors.Default;
        }

        private void GetSharedHeaders()
        {
            List<FileStructure> files = listBox1.Items.Cast<FileStructure>().ToList();
            List<string> shared_headers = files[0].Headers;
            foreach(FileStructure f_struct in files)
            {
                shared_headers = shared_headers.Intersect(f_struct.Headers, new FieldHeaderComparer()).ToList();
                //shared_headers = shared_headers.Union(f_struct.Headers).ToList();
            }

            lstHeaders.Items.Clear();
            lstHeaders.Items.AddRange(shared_headers.ToArray());
        }
    }
}
