using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Interfaces
{
    public interface IStringSearch : IStrategy
    {
        bool HasWithin(string searchFor, string searchWithin);
    }
}
