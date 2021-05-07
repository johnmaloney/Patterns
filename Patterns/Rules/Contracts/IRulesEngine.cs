using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Rules
{
    public interface IRulesEngine<T>
    {
        Task<T> Execute();
    }
}
