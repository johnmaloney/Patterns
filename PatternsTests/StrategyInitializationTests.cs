using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using Patterns.Strategy.Interfaces;
using Patterns.Strategy.Implementations;

namespace PatternsTests
{
    [TestClass]
    public class StrategyInitializationTests
    {
        [TestMethod]
        public void add_strategy_to_collection_expect_retrieval()
        {
            var searchStrategy = new MockStringSearch();
            Strategy.AddStrategy<IStringSearch>(searchStrategy);
            Assert.AreEqual(searchStrategy, Strategy.For<IStringSearch>());
        }

        [TestCleanup]
        public void Cleanup()
        {
            Strategy.AddStrategy<IStringSearch>(new StringSearch());
        }
    }

    [TestClass]
    public class ConcurrentStrategyTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Strategy.AddStrategy<IStringSearch>(new StringSearch());
        }

        [TestMethod]
        public void get_already_added_strategy_expect_instance()
        {
            var stringStrategy = Strategy.For<IStringSearch>();

            // This should not be the StringSearch strategy since it was replaced by the test cleanup //
            Assert.AreEqual(stringStrategy.GetType(), typeof(StringSearch));
        }
    }
    
    [TestClass]
    public class NestedStrategyTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Strategy.AddStrategy<ITree>(new Tree());
            Strategy.AddStrategy<IBranch>(new BranchA());
            Strategy.AddStrategy<ILeaf>(new LeafA());
        }

        [TestMethod]
        public void using_tree_with_leaf_C_expect_response()
        {
            Strategy.AddStrategy<ILeaf>(new LeafC());

            var response = Strategy.For<ITree>().Navigate();

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
            Strategy.AddStrategy<IBranch>(new BranchC());

            var response = Strategy.For<ITree>().Navigate();

            // Should be the default response because it was placed back into the Strategy //
            // after the TestInitialize //
            Assert.AreEqual("This is not the branch you are looking for...", response);
        }
    }

    internal class MockStringSearch : IStringSearch
    {
        public bool HasWithin(string searchFor, string searchWithin)
        {
            throw new NotImplementedException();
        }
    }
}
