using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Strategy;
using Patterns.Strategy.Interfaces;
using Patterns.Strategy.Implementations;

namespace PatternsTests
{
    [TestClass]
    public class StrategyTests
    {
        private string searchWithin = @"Stormtrooper: Let me see your identification.
                                        Ben Obi-Wan Kenobi: [with a small wave of his hand] You don't need to see his identification.
                                        Stormtrooper: We don't need to see his identification.
                                        Ben Obi-Wan Kenobi: These aren't the droids you're looking for.
                                        Stormtrooper: These aren't the droids we're looking for.
                                        Ben Obi - Wan Kenobi: He can go about his business.
                                        Stormtrooper: You can go about your business.
                                        Ben Obi - Wan Kenobi: Move along.
                                        Stormtrooper: Move along...move along.";

        [TestInitialize]
        public void InitializeEachTime()
        {
            Strategy.AddStrategy<IStringSearch>(new StringSearch());
        }

        [TestMethod]
        public void string_search_implementation_expect_results()
        {
            // search for a string that is not properly cased //
            var searchFor = "move Along";
            bool contains = Strategy.For<IStringSearch>().HasWithin(searchFor, searchWithin);
            Assert.IsFalse(contains);

            //switch the strategy to case insensitive, to show the injection potential //
            Strategy.AddStrategy<IStringSearch>(new StringSearchCI());
            contains = Strategy.For<IStringSearch>().HasWithin(searchFor, searchWithin);
            Assert.IsTrue(contains);

            // Revert back to default //
            Strategy.AddStrategy<IStringSearch>(new StringSearch());
            
            // search for a string the is a partial //
            searchFor = "ident";
            contains = Strategy.For<IStringSearch>().HasWithin(searchFor, searchWithin);
            Assert.IsTrue(contains);

            // search for a string that does not exist //
            searchFor = "?";
            contains = Strategy.For<IStringSearch>().HasWithin(searchFor, searchWithin);
            Assert.IsFalse(contains);
        }
    }
}
