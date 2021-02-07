using System;
using System.Text;

namespace CustomDataStructures
{
    class CustomQueue
    {
        private const int constInitialCapacity = 4;
        private int[] items;
        private int count;
        private int first;
        private int last;
        public CustomQueue(int initialCapacity = constInitialCapacity)
        {
            EmptyQueueInitialization(initialCapacity);
        }
        public CustomQueue(int[] array)
        {
            items   = array;
            count   = items.Length;
            first   = 0;
            last    = count - 1;
        }
        void EmptyQueueInitialization(int initialCapacity)
        {
            items = new int[initialCapacity];
            count = 0;
            first = 0;
            last = -1;
        }
        public int Count { get => count; private set => count = value; }
        public void Enqueue(int value)
        {
            if (last == items.Length - 1)
            {
                Resize();
            }

            items[count++] = value;
            last++;
        }
        private void Resize()
        {
            if (first > 0)
            {
                Shift(first);
                first = 0;
                last = Count - 1;
            }
            else
            {
                int[] newarr = new int[items.Length * 2];
                items.CopyTo(newarr, 0);
                items = newarr;
            }
        }
        private void Shift(int offset)
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = items[i + offset];
            }
        }
        public int Dequeue()
        {
            QueueIsEmptyCheck();
            var toReturn = items[first++];

            if (--Count == 0)
            {
                EmptyQueueInitialization(constInitialCapacity);
            }
            else if (Count < items.Length / 4)
            {
                Shrink();
            }

            return toReturn;
        }
        private void Shrink()
        {
            items = InnerToArray(items.Length / 2);
            first = 0;
            last = Count - 1;
        }
        public int Peek()
        {
            QueueIsEmptyCheck();
            return items[first];
        }
        private void QueueIsEmptyCheck()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }
        public void ForEach(Action<object> action)
        {

            for (int i = first; i <= last; i++)
            {
                action(items[i]);
            }
        }
        public void Clear()
        {
            EmptyQueueInitialization(constInitialCapacity);
        }
        public int[] ToArray()
        {
            return InnerToArray(Count);
        }
        private int[] InnerToArray(int lenght)
        {
            int[] retArr = new int[lenght];
            int idx = 0;

            ForEach(i => retArr[idx++] = (int)i);

            return retArr;
        }
        public override string ToString()
        {
            // return string.Join(" ", ToArray()); // Returns only String.Join of the List
            // Next lines are for testing
            var sb = new StringBuilder();
            sb.Append(string.Join(" ", ToArray())).Append($" Count: { Count.ToString()}\n");
            sb.Append(string.Join(" ", items)).Append($"\tInner Array");
            return sb.ToString();
        }
    }
}
