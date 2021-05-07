using Patterns.Rules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules
{
    public interface IRule
    {
        void Evaluate(IRuleContext context);
        bool ShouldEvaluate(IRuleContext context);
    }

    public interface IRuleContext
    {
        IEnumerable<IRuleMessage> Messages { get; }

        void AddMessage(IRuleMessage message);
    }
}
