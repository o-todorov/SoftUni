using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(params int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            int idx = 0;

            for (idx = 0; idx < stones.Length; idx += 2)
            {
                yield return stones[idx];
            }

            idx = --idx < stones.Length ? idx : idx - 2;

            for (; idx >= 1; idx -= 2)
            {
                yield return stones[idx];
            }
        }
    }
}
