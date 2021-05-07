using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency.Contracts
{
    public interface ICurrencyRepository
    {
        IReadOnlyDictionary<string, double> CurrentRates { get; }
    }
}
