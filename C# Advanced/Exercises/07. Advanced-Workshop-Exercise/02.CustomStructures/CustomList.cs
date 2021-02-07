using System;
using System.Linq;
using System.Text;

namespace CustomDataStructures
{
    class CustomList
    {
        private const int constInitialCapacity = 2;
        private int[] items;
        private int count;
        public CustomList(int initialCapacity = constInitialCapacity)
        {
            Init(initialCapacity);
        }
        public CustomList(int[]array)
        {
            items = array;
            count = items.Length;
        }
        public CustomList(int rangeFirst,int rangeLast)
        {
            items = Enumerable.Range(rangeFirst, rangeLast - rangeFirst + 1).ToArray();
            count = items.Length;
        }
        public int Count { get => count; private set => count = value; }
        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }
        public void Add(int value)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = value;
        }
        public void Insert(int index, int value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            ShiftRight(index);
            items[index] = value;
            Count++;
        }
        public int RemoveAt(int index)
        {
            ValidateIndex(index);

            int retVal = items[index];
            ShiftLeft(index);

            if (--Count <= items.Length / 4 && Count > 0)
            {
                Shrink();
            }

            return retVal;
        }
        private void Resize()
        {
            items = GetNewSizeArray(items.Length * 2);
        }
        private void Shrink()
        {
            items = GetNewSizeArray(items.Length / 2);
        }
        private int[] GetNewSizeArray(int newsize)
        {
            int[] newarr = new int[newsize];
            Array.Copy(items, newarr, Count);
            return newarr;
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public bool Contains(int element)
        {
            return Find(element) != -1;
        }
        public int Find(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }
        public void Swap(int firstIdx, int secondIdx)
        {
            ValidateIndex(firstIdx);
            ValidateIndex(secondIdx);

            int temp    = items[firstIdx];
            items[firstIdx] = items[secondIdx];
            items[secondIdx] = temp;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        public CustomList Where(Predicate<int> filter)
        { // Returns nnew CustomList instance !!!
            var newarr = new int[Count];
            int idx = 0;
            ForEach(elem => { if (filter(elem)) newarr[idx++] = elem; });
            var arr = new int[idx];
            Array.Copy(newarr, arr, idx);

            return new CustomList(arr);
        }
        public void Reverse()
        {
            int[] newArr = new int[items.Length];
            int idx = 0;

            for (int i = Count - 1; i >= 0; i--)
            {
                newArr[idx++] = items[i];
            }

            items = newArr;

        }
        public int[] ToArray()
        {
            int[] retArr = new int[Count];
            Array.Copy(items, retArr, Count);

            return retArr;
        }
        public void Clear()
        {
            Init(constInitialCapacity);
        }
        private void Init(int initialCapacity)
        {
            items = new int[initialCapacity];
            count = 0;
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
