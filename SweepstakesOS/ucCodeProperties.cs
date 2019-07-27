using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SweepstakesOS
{
    public partial class ucCodeProperties : UserControl
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private string m_charset = "";

        public int CodeLength { get { return (int)numericUpDown1.Value; } }
        public string Charset { get { return m_charset; } }
        public double MaximumCodes { get; private set; }

        public ucCodeProperties()
        {
            InitializeComponent();

            RecalculateMaxUniqueCodes();
        }

        private void RecalculateMaxUniqueCodes()
        {
            int N = (int)numericUpDown1.Value;
            double max = 0;

            //Exclude
            m_charset = chars;

            string[] exclude_chars = txtExcludes.Text.Split(',');
            foreach(string s in exclude_chars)
                m_charset = m_charset.Replace(s, "");

            int M = m_charset.Length;

            max = Math.Pow(M,N);

            MaximumCodes = max;
            lblMax.Text = max + " maximum codes";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RecalculateMaxUniqueCodes();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            RecalculateMaxUniqueCodes();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            RecalculateMaxUniqueCodes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            RecalculateMaxUniqueCodes();
        }
    }
}
