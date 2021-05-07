using Newtonsoft.Json;
using Patterns.Rules.Currency.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    public class ExchangeRateCurrencyRepository : ICurrencyRepository
    {
        #region Fields

        #endregion

        #region Properties

        public IReadOnlyDictionary<string, double> CurrentRates { get; }

        #endregion

        #region Methods

        public ExchangeRateCurrencyRepository(IExchangeDataLocator locator)
        {
            this.CurrentRates = locator.Rates;
        }

        public double GetMostRecentCurrencyRate(string currency)
        {
            return this.CurrentRates[currency];
        }

        #endregion
    }
}

