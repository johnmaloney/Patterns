using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTests
{
    public static class TestExtensions
    {
        public static Stack<int> AddRange(this Stack<int> source, int amountToAdd)
        {
            for (int i = amountToAdd; i > 0; i--)
            {
                source.Push(i);
            }
            return source;
        }
    }
}
