using Patterns.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy.Implementations
{
    /// <summary>
    /// Represents the use of a nested strategy
    /// </summary>
    public class Tree : ITree
    {
        public string Navigate()
        {
            return Strategy.For<IBranch>().Navigate();
        }
    }

    public class BranchA : IBranch
    {
        public string Navigate()
        {
            return Strategy.For<ILeaf>().Read();
        }
    }

    public class BranchB : IBranch
    {
        public string Navigate()
        {
            var leaf = new LeafB();
            return leaf.Read();
        }
    }

    public class BranchC : IBranch
    {
        public string Navigate()
        {
            return "This is not the branch you are looking for...";
        }
    }

    public class LeafA : ILeaf
    {
        public string Read()
        {
            return "Read Leaf A";
        }
    }

    public class LeafB : ILeaf
    {
        public string Read()
        {
            return "Read Leaf B";
        }
    }

    public class LeafC : ILeaf
    {
        public string Read()
        {
            return "Read Leaf C";
        }
    }
}
