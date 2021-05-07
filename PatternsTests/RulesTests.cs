using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Rules.Contracts;
using Patterns.Rules.Currency;
using PatternsTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTests
{
    [TestClass]
    [DeploymentItem("Mocks/rates.json", "/")]
    public class RulesTests
    {
        [TestMethod]
        public void using_the_rules_engine_expect_rules_list()
        {

        }

        [TestMethod]
        public async Task given_rates_data_converrt_currency_to_USD()
        {
            var dataLocator = new MockExchangeRateAPI();
            var repository = new ExchangeRateCurrencyRepository(dataLocator);

            var context = new CurrencyContext(100.00)
            {
                CurrencyTo = "EUR",
                CurrencyFrom = "USD"
            };

            var engine = new ExchangeCurrencyRulesEngine(context, repository);
            IRuleResult<double> result = await engine.Execute();
        }
    }
}
