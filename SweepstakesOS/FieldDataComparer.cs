using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweepstakesOS
{
    public class FieldDataComparer : IEqualityComparer<string>
    {
        #region IEqualityComparer<string> Members

        public bool Equals(string x, string y)
        {
            x = x.ToLower(); y = y.ToLower();

            //Check whether the objects are the same object. 
            if(Object.ReferenceEquals(x, y)) return true;

            //Check whether the products' properties are equal.
            if(x == null || y == null)
                return false;

            if(x.Equals(y, StringComparison.CurrentCultureIgnoreCase))
                return true;

            //If 5(N) Consective Characters are a match, consider equal
            int N = 5;

            for(int i = 0; i < x.Length - N; i++)
            {
                //Loop through, get N character 'chunks'
                string chunk = x.Substring(i, N);

                if(y.Contains(chunk)) return true;
            }

            return false;
        }

        public int GetHashCode(string obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashProductName = obj == null ? 0 : obj.GetHashCode();

            //Get hash code for the Code field. 
            int hashProductCode = obj.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }

        #endregion
    }
}
