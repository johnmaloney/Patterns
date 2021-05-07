using Patterns.Rules.Currency.Contracts;

namespace Patterns.Rules.Currency
{
    internal class ExchangeFeeCurrencyRule : ICurrencyRule
    {
        public void Evaluate(IRuleContext context)
        {
            var currencyContext = context as ICurrencyContext;
            currencyContext.CurrentValue = currencyContext.CurrentValue - (.10 * currencyContext.CurrentValue);
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

            if (currencyContext.CurrentValue <=0.0)
            {
                context.AddMessage(new GeneralRuleMessage { Title = "The converted currency was zero, a fee cannot be assessed." });
                shouldEvaluate = false;
            }

            return shouldEvaluate;
        }
    }
}