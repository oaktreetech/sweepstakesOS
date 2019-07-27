using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweepstakesOS
{
    class Entry
    {
        public List<string> Data { get; private set; }

        public Entry(string[] p_data)
        {
            Data = p_data.ToList<string>();

            //Data = new List<EntryField>();
            //foreach(string s in p_data)
            //    Data.Add(new EntryField(s));
        }
    }
}
