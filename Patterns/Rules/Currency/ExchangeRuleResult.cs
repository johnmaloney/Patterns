using Patterns.Rules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    public class ExchangeRuleResult : IRuleResult<double>
    {
        public double Result { get; private set; }

        public IEnumerable<IRuleMessage> Messages { get; private set; }

        public void AddMessages(IEnumerable<IRuleMessage> messages)
        {
            this.Messages = messages;
        }
    }
}
