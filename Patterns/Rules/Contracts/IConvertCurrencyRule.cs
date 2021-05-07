using Patterns.Rules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency.Contracts
{
    interface ICurrencyRule : IRule
    {
    }

    public interface ICurrencyContext : IRuleContext
    {
        double OriginalValue { get; }
        double ConvertedValue { get; set; }
        double CurrentValue { get; set; }
        double FeePercentage { get; set; }
        string CurrencyFrom { get; set; }
        string CurrencyTo { get; set; }
    }
}
