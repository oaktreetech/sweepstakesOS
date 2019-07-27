using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweepstakesOS
{
    /// <summary>
    /// 
    /// 
    /// https://en.wikipedia.org/wiki/Levenshtein_distance
    /// 
    /// 
    /// 
    /// </summary>
    public class LevenshteinDistanceStringComparer : IEqualityComparer<string>
    {

        private readonly int threshold = 5;

        #region Original Method

        /*
         * if(n == 0)
            {
                return m;
            }

            if(m == 0)
            {
                return n;
            }

            // Step 2
            for(int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for(int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for(int i = 1; i <= n; i++)
            {
                //Step 4
                for(int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
         * 
         */

        #endregion

        public LevenshteinDistanceStringComparer() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thresh">Change Threshold, higher -> more time to perform</param>
        public LevenshteinDistanceStringComparer(int thresh)
        {
            threshold = thresh;
        }

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


            #region Levenshtein Method

            int n = x.Length;
            int m = y.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if(n == 0)
            {
                return false;
            }

            if(m == 0)
            {
                return false;
            }

            // Step 2
            for(int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for(int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for(int i = 1; i <= n; i++)
            {
                //Step 4
                for(int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (y[j - 1] == x[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m] <= threshold;

            #endregion
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
