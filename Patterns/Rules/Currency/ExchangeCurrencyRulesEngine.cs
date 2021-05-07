using Patterns.Rules.Contracts;
using Patterns.Rules.Currency.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    /// <summary>
    /// The Rules Engine is the ultimate host of the process model.
    /// </summary>
    public class ExchangeCurrencyRulesEngine : IRulesEngine<IRuleResult<double>>
    {
        private readonly ICurrencyRepository ratesRepository;
        private readonly ICurrencyContext currencyContext;
        private readonly List<IRule> feeBasedExchangeRules;

        public ExchangeCurrencyRulesEngine(ICurrencyContext context, ICurrencyRepository ratesRepository)
        {            
            this.currencyContext = context;
            this.ratesRepository = ratesRepository;
            feeBasedExchangeRules = new List<IRule> 
            { 
                new CurrentCurrencyExchangeRatesRule(this.ratesRepository), 
                new ExchangeFeeCurrencyRule() 
            };
        }

        /// <summary>
        /// Default implementation of the Rules Engine
        /// </summary>
        /// <returns>double</returns>
        public Task<IRuleResult<double>> Execute()
        {
            foreach(ICurrencyRule rule in feeBasedExchangeRules)
            {
                if(rule.ShouldEvaluate(currencyContext))
                    rule.Evaluate(currencyContext);
            }

            IRuleResult<double> result = new ExchangeRuleResult();
            result.AddMessages(currencyContext.Messages);

            return Task.FromResult(result);
        }
    }
}
