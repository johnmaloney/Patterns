using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using Patterns.Strategy.Implementations;
using Patterns.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTests.Base
{
    [TestClass]
    public abstract class ATest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Forces the default registration of the IStringSearch Strategy //
            Strategy.AddStrategy<IStringSearch>(new StringSearch());

            Strategy.AddStrategy<ITree>(new Tree());
            Strategy.AddStrategy<IBranch>(new BranchA());
            Strategy.AddStrategy<ILeaf>(new LeafA());
        }
    }
}
