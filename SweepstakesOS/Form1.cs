using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SweepstakesOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMultiplyEntries frmMultiply = new frmMultiplyEntries();

            frmMultiply.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmWinnerSelection frmWinners = new frmWinnerSelection();

            frmWinners.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUniqueCodeGenerator frmCodes = new frmUniqueCodeGenerator();

            frmCodes.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmRulesOnly frmRules = new frmRulesOnly();

            frmRules.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAppendMailIns frmAppendMailIns = new frmAppendMailIns();

            frmAppendMailIns.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmExcludeEntries frm = new frmExcludeEntries();

            frm.ShowDialog(this);
        }

        private void cmdUnion_Click(object sender, EventArgs e)
        {
            frmUnion frmUnion = new frmUnion();

            frmUnion.ShowDialog(this);
        }
    }
}
