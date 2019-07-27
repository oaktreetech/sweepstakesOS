using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweepstakesOS
{
    class EntryField
    {
        private string m_value = "";

        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public EntryField() { }
        public EntryField(string s) { Value = s; }
    }
}
