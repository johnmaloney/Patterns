using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Interfaces
{
    public interface ITree : IStrategy
    {
        string Navigate();
    }

    public interface IBranch : IStrategy
    {
        string Navigate();
    }

    public interface ILeaf : IStrategy
    {
        string Read();
    }
}
