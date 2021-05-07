using System.Collections.Generic;

namespace Patterns.Rules.Currency.Contracts
{
    public interface IExchangeDataLocator
    {
        IReadOnlyDictionary<string, double> Rates { get; }
    }
}