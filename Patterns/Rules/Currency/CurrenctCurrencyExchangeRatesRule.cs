using Patterns.Rules.Currency.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    public class CurrentCurrencyExchangeRatesRule : ICurrencyRule
    {
        private readonly ICurrencyRepository ratesRepository;

        public CurrentCurrencyExchangeRatesRule(ICurrencyRepository ratesRepository)
        {
            this.ratesRepository = ratesRepository;
        }

        public void Evaluate(IRuleContext context)
        {
            var currencyContext = context as ICurrencyContext;
            var exchangeRate = ratesRepository.CurrentRates[currencyContext.CurrencyTo];
            currencyContext.CurrentValue = currencyContext.OriginalValue * exchangeRate;
        }

        public bool ShouldEvaluate(IRuleContext context)
        {
            bool shouldEvaluate = true;

            if (context is not ICurrencyContext)
            {
                context.AddMessage(new GeneralRuleMessage { Title = "The context was not of type ICurrencyContext." });
                shouldEvaluate = false;
            }
            
            var currencyContext = context as ICurrencyContext;

            if (string.IsNullOrEmpty(currencyContext.CurrencyTo) || string.IsNullOrEmpty(currencyContext.CurrencyFrom))
            {
                context.AddMessage(new GeneralRuleMessage { Title = "The Currency Rates data was not available." });
                shouldEvaluate = false;
            }

            return shouldEvaluate;
        }
    }
}
