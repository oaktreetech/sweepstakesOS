using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SweepstakesOS
{
    public partial class frmAppendMailIns : Form
    {
        public frmAppendMailIns()
        {
            InitializeComponent();
        }

        private void cmdAppend_Click(object sender, EventArgs e)
        {
            string filename = ucEntryFileOpenControl1.FilePath;

            if(Program.IsFileOpen(filename))
            {
                MessageBox.Show("File '" + filename + "' is already opened. Please close the file and retry.");
                return;
            }

            string output_file = "";
            switch(ucEntryFileOpenControl1.FileType)
            {
                case FileType.CSV:
                    //output_file = FileOperations.WriteCSV(filename, (int)numEntriesPerMailIn.Value);
                    output_file = WriteCSV(filename, (int)numEntriesPerMailIn.Value);
                    break;
                case FileType.XLS:
                    break;
                default:
                    break;
            }

            Process.Start(output_file);
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

        private string WriteCSV(string filepath, int entries_per_mail_in)
        {
            string input_file = filepath;
            string output_file = Path.GetDirectoryName(input_file)
                + @"\" + Path.GetFileNameWithoutExtension(input_file) + "_with_mail_ins"
                + Path.GetExtension(input_file);

            if(!File.Exists(input_file))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            //Copy File To Append
            File.Copy(input_file, output_file, true);

            int lines_written = 0;
            int mail_ins = (int)numMailIns.Value;
            int entries_per_mail = (int)numEntriesPerMailIn.Value;
            string text_to_write = txtWriteName.Text;

            using(StreamReader input_reader = new StreamReader(input_file))
            using(StreamWriter output_writer = new StreamWriter(output_file, true))
            {
                //Copy Headers
                //output_writer.WriteLine(input_reader.ReadLine());
                //lines_written++;

                //Multiply Out
                for(int i = 0; i < mail_ins; i++)
                {
                    for(int j = 0; j < entries_per_mail; j++)
                    {
                        output_writer.WriteLine(text_to_write + " #" + (i + 1));
                    }
                }
            }

            //MessageBox.Show(lines_written + " lines written.");

            return output_file;
        }

    }
}
