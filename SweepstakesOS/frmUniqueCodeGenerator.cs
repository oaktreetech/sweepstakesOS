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
    public partial class frmUniqueCodeGenerator : Form
    {
        public frmUniqueCodeGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ucCodeProperties1.MaximumCodes < (int)numericUpDown1.Value)
            {
                MessageBox.Show(this, "Not Possible to Create that Number of Codes. Adjust your Character Set Values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> codes = CreateCodes(ucCodeProperties1.CodeLength, (int)numericUpDown1.Value, ucCodeProperties1.Charset);

            saveFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            if(saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string filepath = saveFileDialog1.FileName;

                WriteCSV(codes, filepath);

                Process.Start(filepath);
            }
        }

        /// <summary>
        /// Creates unique codes of length <code>code_length</code>
        /// 
        /// </summary>
        /// <param name="code_length"></param>
        /// <returns></returns>
        public static List<string> CreateCodes(int code_length, int total_codes, string charset)
        {
            int misses = 0;
            List<string> codes = new List<string>();
            Random random = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);

            while(codes.Count < total_codes)
            {
                #region Create Code

                StringBuilder new_code = new StringBuilder(code_length);
                for(int i = 0; i < code_length; i++)
                {
                    int character = random.Next(0, charset.Length);

                    //Digit
                    if(character >= 0 && character < 10)
                    {
                        new_code.Append(character);
                    }
                    else
                    {
                        char c = (char)(character + 55);

                        //if(c != 'O' && c != 'I')
                        if(charset.Contains(c))
                        {
                            new_code.Append(c);
                        }
                        else
                        {
                            i--;
                        }
                    }
                }

                #endregion

                if(!codes.Contains(new_code.ToString()) && Validate(new_code.ToString()))
                {
                    codes.Add(new_code.ToString());
                }
                else
                {
                    misses++;
                }
            }

            return codes;
        }

        public static bool Validate(string code)
        {

            //Must contain at least one letter
            bool CONTAINS_MORE_THAN_ONE_LETTER = false;
            int num_letters = 0;
            for(int i = 0; i < code.Length; i++)
            {
                if(char.IsLetter(code[i]))
                    num_letters++;

                if(num_letters >= 2)
                {
                    CONTAINS_MORE_THAN_ONE_LETTER = true;
                    break;
                }
            }

            //Check for 'E', if present make sure at least one other character is present
            //bool CONTAINS_MORE_THAN_ONE_E = false;
            //if(code.Contains('E'))
            //{
            //    int e_index = code.IndexOf('E');

            //    for(int i = 0; i < code.Length; i++)
            //    {
            //        if(i == e_index)
            //            continue;

            //        if(char.IsLetter(code[i]))
            //        {
            //            CONTAINS_MORE_THAN_ONE_E = true;
            //            break;
            //        }
            //    }
            //}

            return CONTAINS_MORE_THAN_ONE_LETTER;
        }

        public static void WriteCSV(List<string> codes, string path)
        {
            using(StreamWriter writer = new StreamWriter(path, false))
            {
                foreach(string s in codes)
                {
                    writer.WriteLine(s);
                }
            }
        }

    }
}
