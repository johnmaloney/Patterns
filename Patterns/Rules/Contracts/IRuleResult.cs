using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules.Contracts
{
    public interface IRuleMessage
    {
        string Title { get; set;}
    }

    public interface IRuleResult<T>
    {
        T Result { get; }

        IEnumerable<IRuleMessage> Messages { get; }

        void AddMessages(IEnumerable<IRuleMessage> messages);
    }
}
