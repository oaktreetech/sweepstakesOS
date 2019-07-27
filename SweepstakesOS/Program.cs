using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SweepstakesOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool IsFileOpen(string file)
        {
            try
            {
                using(StreamReader input_reader = new StreamReader(file))
                {
                }
            }
            catch(IOException ioexc)
            {
                return true;
            }
            return false;
        }
    }
}
