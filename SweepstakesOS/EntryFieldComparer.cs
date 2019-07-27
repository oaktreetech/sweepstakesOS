using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweepstakesOS
{
    public class FieldHeaderComparer : IEqualityComparer<string>
    {

        private string[][] HardCodedEquals = new string[][]
        {
            new string[]{"first name","first"},
            new string[]{"last name","last"},
            new string[]{"company 1","company"},
            new string[]{"zip","zipcode","postal code"},
            new string[]{"email","email address"}
        };

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

            //Special Cases
            for(int i = 0; i < HardCodedEquals.GetLength(0); i++)
            {
                List<string> like_strings = new List<string>();
                for(int j = 0; j < HardCodedEquals[i].Length; j++)
                    like_strings.Add(HardCodedEquals[i][j]);

                if(like_strings.Contains(x) && like_strings.Contains(y))
                    return true;

                //if((x == HardCodedEquals[i, 0] && y == HardCodedEquals[i, 1]) || (y == HardCodedEquals[i, 0] && x == HardCodedEquals[i, 1]))
                //    return true;
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
