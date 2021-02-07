using System;
using System.Text;

namespace CustomDataStructures
{
    class CustomStack
    {
        private const int constInitialCapacity = 4;
        private int[] items;
        private int count;
        public CustomStack(int initialCapacity = constInitialCapacity)
        {
            count = 0;
            items = new int[initialCapacity];
        }
        public CustomStack(int[] array)
        {
            items = array;
            count = items.Length;
        }
        public int Count { get => count; private set => count = value; }
        public void Push(int value)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = value;
        }
        private void Resize()
        {
            int[] newarr = new int[items.Length * 2];
            items.CopyTo(newarr, 0);
            items = newarr;
        }
        public int Pop()
        {
            StackIsEmptyCheck();
            int toReturn = items[Count - 1];

            if (--count <= items.Length / 4 && Count > 0)
            {
                items = InnerToArray(items.Length / 2);
            }

            return toReturn;
        }
        public int Peek()
        {
            StackIsEmptyCheck();
            return items[Count - 1];
        }
        private void StackIsEmptyCheck()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Custom Stack is empty");
            }
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        public void Clear()
        {
            items = new int[constInitialCapacity];
            Count = 0;
        }
        public int[] ToArray()
        {
            return InnerToArray(Count);
        }
        private int[] InnerToArray(int lenght)
        {
            int[] retArr = new int[lenght];

            for (int i = 0; i < Count; i++)
            {
                retArr[i] = items[i];
            }

            return retArr;
        }
        public override string ToString()
        {
            // return string.Join(" ", ToArray()); // Returns only String.Join of the List
            // Next lines are for testing
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(" ", ToArray()) + " Count: " + Count.ToString());
            sb.Append(string.Join(" ", items)).Append($"\tInner Array");
            return sb.ToString();
        }
    }
}
