using Patterns.Rules.Contracts;
using Patterns.Rules.Currency.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    public class CurrencyContext : ICurrencyContext
    {
        public double OriginalValue { get; }
        public double CurrentValue { get; set; }
        public double ConvertedValue { get; set; }
        public double FeePercentage { get; set; }
        public IEnumerable<IRuleMessage> Messages { get; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }

        public CurrencyContext(double originalCurrencyValue)
        {
            this.OriginalValue = originalCurrencyValue;
        }

        public void AddMessage(IRuleMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
