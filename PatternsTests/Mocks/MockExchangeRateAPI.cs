using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Patterns.Rules.Currency;
using Patterns.Rules.Currency.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTests.Mocks
{
    public class MockExchangeRateAPI : IExchangeDataLocator
    {
        private IReadOnlyDictionary<string, double> rates;
        IReadOnlyDictionary<string, double> IExchangeDataLocator.Rates => rates;

        public MockExchangeRateAPI()
        {
            string location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            rates = JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText(location + @"\Mocks\rates.json"));
        }
    }
}
