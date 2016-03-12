using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Recursion
{
    /// <summary>
    /// In mathematics, the notion of permutation relates to the act of arranging all 
    /// the members of a set into some sequence or order, or if the set is already ordered, 
    /// rearranging (reordering) its elements, a process called permuting.
    /// https://www.youtube.com/watch?v=NdF1QDTRkck 
    /// </summary>
    public class Permutations
    {
        #region Fields
        #endregion

        #region Properties

        public List<string> Results
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public Permutations()
        {
            this.Results = new List<string>();
        }

        /// <summary>
        /// Iterates the text to find every possible combination of the text.
        /// e.g. ABCD permutes to ACDB, ADBC, BCDA, BDAC ...
        /// </summary>
        /// <param name="soFar"></param>
        /// <param name="rest"></param>
        public void PermuteText(string soFar, string rest)
        {
            if (string.IsNullOrEmpty(rest))
                this.Results.Add(soFar);
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = soFar + rest[i];
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);

                    PermuteText(next, remaining);
                }
            }
        }

        /// <summary>
        /// Iterates the string finding the biggest set and then removes one
        /// at a time to get the lowest possible combination.
        /// </summary>
        /// <param name="soFar"></param>
        /// <param name="rest"></param>
        public void SubsetText(string soFar, string rest)
        {
            if (string.IsNullOrEmpty(rest))
                this.Results.Add(soFar);
            else
            {
                // Add to subset, remove from rest, recur //
                SubsetText(soFar + rest[0], rest.Substring(1));

                // Dont add to the subset, remove from the rest,recur //
                SubsetText(soFar, rest.Substring(1));
            }
        }

        #endregion        
    }
}
