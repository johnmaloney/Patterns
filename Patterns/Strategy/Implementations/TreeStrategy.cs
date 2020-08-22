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
        public string Navigate(As version = As.Default)
        {
            return Strategy.For<IBranch>(version).Navigate(version);
        }
    }

    public class BranchA : IBranch
    {
        public string Navigate(As version = As.Default)
        {
            return Strategy.For<ILeaf>(version).Read(version);
        }
    }

    public class BranchB : IBranch
    {
        public string Navigate(As version = As.Default)
        {
            var leaf = new LeafB();
            return leaf.Read(version);
        }
    }

    public class BranchC : IBranch
    {
        public string Navigate(As version = As.Default)
        {
            return "This is not the branch you are looking for...";
        }
    }

    public class LeafA : ILeaf
    {
        public string Read(As version = As.Default)
        {
            return "Read Leaf A";
        }
    }

    public class LeafB : ILeaf
    {
        public string Read(As version = As.Default)
        {
            return "Read Leaf B";
        }
    }

    public class LeafC : ILeaf
    {
        public string Read(As version = As.Default)
        {
            return "Read Leaf C";
        }
    }
}
