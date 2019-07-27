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
    public partial class frmWinnerSelection : Form
    {
        private List<string[]> Entrants = new List<string[]>();
        private List<string[]> Winners = new List<string[]>();
        private FileType FileType { get; set; }
        private string FilePath { get; set; }

        public frmWinnerSelection()
        {
            InitializeComponent();
        }

        private void frmWinnerSelection_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = decimal.MaxValue;
        }

        private void ReadWinnersCSV(string filepath)
        {
            Entrants = new List<string[]>();
            string input_file = filepath;

            if(!File.Exists(input_file))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            int lines_read = 0;
            using(StreamReader input_reader = new StreamReader(input_file))
            {
                //Iterate Lines
                string line = "";
                while((line = input_reader.ReadLine()) != null)
                {
                    //Remove "\"" and enclosed ','
                    if(line.Contains("\""))
                    {
                        int start = line.IndexOf("\"");
                        int end = line.IndexOf("\"", start + 1);

                        if(end < start)
                        {

                        }
                        else
                        {
                            string enclosed = line.Substring(start + 1, end - start - 1);
                            string new_enclosed = enclosed.Replace(",", " ");
                            line = line.Replace(enclosed, new_enclosed);
                        }
                    }

                    line = line.Replace("\"", "");

                    Entrants.Add(line.Split(','));

                    lines_read++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Winners = new List<string[]>();
            int total_winners = (int)numericUpDown1.Value;

            switch(ucEntryFileOpenControl1.FileType)
            {
                case FileType.CSV:
                    ReadWinnersCSV(ucEntryFileOpenControl1.FilePath);
                    break;
                case FileType.XLS:
                    break;
                default:
                    break;
            }

            //Select Winners
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<int> selected = new List<int>();
            for(int i = 0; i < total_winners; i++)
            {
                //Ensure Unique Selection
                int selection = rnd.Next(Entrants.Count);
                while(selected.Contains(selection))
                    selection = rnd.Next(Entrants.Count);

                Winners.Add(Entrants[selection]);
            }

            //Display Winners
            DataTable table = new DataTable();
            int value_number = 1;
            //foreach(string s in Winners[0])
            //    table.Columns.Add("Value" + value_number++);
            int max = Winners.Max(x => x.Length);
            for(int i = 1; i <= max; i++)
            {
                table.Columns.Add("Value" + i);
            }

            foreach(string[] fields in Winners)
                table.Rows.Add(fields);

            dataGridView1.DataSource = table;
        }

        private void newFileSelected(object sender, EventArgs e)
        {
            //Do Nothing
        }
    }
}
