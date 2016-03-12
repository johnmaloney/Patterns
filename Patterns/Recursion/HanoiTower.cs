using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Recursion
{
    /// <summary>
    /// Hanoi or Brahma Tower problem, helpful lesson:
    /// https://www.youtube.com/watch?v=uFJhEPrbycQ
    /// </summary>
    public class HanoiTower
    {
        public void MoveTower(int n, Stack<int> source, Stack<int> destination, Stack<int> temporary)
        {
            if (n > 0)
            {
                // Move Down the tree //
                MoveTower(n - 1, source, temporary, destination);
                // Move the current disk onto the TEMPORARY stack //
                MoveSingleDisk(source, destination);
                // check if this is the end //
                MoveTower(n - 1, temporary, destination, source);
            }
        }

        public void MoveSingleDisk(Stack<int> source, Stack<int> destination)
        {
            var itemMoving = source.Pop();

            if (destination.Count > 0)
            {
                // Ensure that the rule of never stacking a higher number //
                // on a lower number is enforced //
                var destinationTop = destination.Peek();

                if (destinationTop < itemMoving)
                    throw new InvalidOperationException(
                        "The rule that a higher numbered disk cannot be placed on a lower numbered disk was violated. Higher: "
                        + destinationTop + " Lower: " + itemMoving);
            }

            destination.Push(itemMoving);
        }
    }
}
