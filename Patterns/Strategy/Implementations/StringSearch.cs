using Patterns.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Implementations
{
    public class StringSearch : IStringSearch
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods

        public StringSearch()
        {

        }

        public bool HasWithin(string searchFor, string searchWitin)
        {
            return searchWitin.Contains(searchFor);
        }

        #endregion
    }

    public class StringSearchCI : IStringSearch
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods

        public StringSearchCI()
        {

        }

        public bool HasWithin(string searchFor, string searchWitin)
        {
            return searchWitin.IndexOf(searchFor, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        #endregion
    }
}
