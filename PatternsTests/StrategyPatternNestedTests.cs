using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using Patterns.Strategy.Interfaces;
using Patterns.Strategy.Implementations;
using PatternsTests.Base;

namespace PatternsTests
{
    [TestClass]
    public class NestedStrategyTests : ATest
    {
        [TestMethod]
        public void using_tree_with_leaf_C_expect_response()
        {
            Strategy.AddStrategy<ITree>(new Tree(), As.v1);
            Strategy.AddStrategy<IBranch>(new BranchA(), As.v1);
            // NOTE the BRANCH C use //
            Strategy.AddStrategy<ILeaf>(new LeafC(), As.v1);

            var response = Strategy.For<ITree>(As.v1).Navigate(As.v1);

            // this will be the "Read Leaf C" because of the injection //
            // of the LeafC strategy in this method //
            Assert.AreEqual("Read Leaf C", response);
        }

        [TestMethod]
        public void using_tree_with_defaults_expect_default_response()
        {
            var response = Strategy.For<ITree>().Navigate();

            // Should be the default response because it was placed back into the Strategy //
            // after the TestInitialize //
            Assert.AreEqual("Read Leaf A", response);
        }

        [TestMethod]
        public void using_tree_with_different_branch_expect_explicit_response()
        {
            Strategy.AddStrategy<ITree>(new Tree(), As.v2);
            // NOTE the BRANCH C use //
            Strategy.AddStrategy<IBranch>(new BranchC(), As.v2);
            Strategy.AddStrategy<ILeaf>(new LeafA(), As.v2);

            var response = Strategy.For<ITree>(As.v2).Navigate(As.v2);

            // Should be the default response because it was placed back into the Strategy //
            // after the TestInitialize //
            Assert.AreEqual("This is not the branch you are looking for...", response);
        }
    }

}
