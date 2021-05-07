using Patterns.Rules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Currency
{
    public class GeneralRuleMessage : IRuleMessage
    {
        public string Title { get; set; }
    }
}
