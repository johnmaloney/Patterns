using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using Patterns.Strategy.Interfaces;
using Patterns.Strategy.Implementations;
using PatternsTests.Base;

namespace PatternsTests
{
    [TestClass]
    public class StrategyInitializationTests : ATest
    {
        [TestMethod]
        public void add_strategy_to_collection_expect_retrieval_as_version()
        {
            var searchStrategy = new MockStringSearch();
            Strategy.AddStrategy<IStringSearch>(searchStrategy, As.v1);
            Assert.AreEqual(searchStrategy, Strategy.For<IStringSearch>(As.v1));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void add_default_strategy_expect_exception_due_to_existing_registration()
        {
            // This is a BOMB, it go BOOM //
            Strategy.AddStrategy<IStringSearch>(new StringSearch(), As.Default);
        }
    }

    [TestClass]
    public class ConcurrentStrategyTests
    {
        [TestMethod]
        public void get_already_added_strategy_expect_instance()
        {
            var stringStrategy = Strategy.For<IStringSearch>();

            // This should not be the StringSearch strategy since it was replaced by the test cleanup //
            Assert.AreEqual(stringStrategy.GetType(), typeof(StringSearch));
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
