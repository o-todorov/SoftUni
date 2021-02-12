using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        private int count = 0;
        private ListNode<T> Head;
        private ListNode<T> Tail;
        public DoublyLinkedList() 
        {
            Count = 0;
        }
        public DoublyLinkedList(IEnumerable array) :this()
        {
            foreach (T item in array)
            {
                this.AddLast(item);
            }
        }
        public int Count { get => count; private set => count = value; }
        public T First 
        {
            get 
            {
                CheckListIsEmpty();
                return Head.Value;
            } 
        }
        public T Last
        {
            get
            {
                CheckListIsEmpty();
                return Tail.Value;
            }
        }
        public void AddFirst(T value)
        {
            ListNode<T> node = new ListNode<T>(value);
            Count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }
        public void AddLast(T value)
        {
            var node = new ListNode<T>(value);
            Count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }
        public T RemoveFirst()
        {
            CheckListIsEmpty();

            T ret = Head.Value;
            Head = Head.Next;
            Count--;

            if (Count == 0)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }

            return ret;
        }
        public T RemoveLast()
        {
            CheckListIsEmpty();

            T ret = Tail.Value;
            Tail = Tail.Previous;
            Count--;

            if (Count == 0)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }

            return ret;
        }
        public void ForEach(Action<T> doAction)
        {
            var curr = Head;

            while (curr != null)
            {
                doAction(curr.Value);
                curr = curr.Next;
            }
        }
        public T[] ToArray()
        {
            T[] ret = new T[Count];
            int idx = 0;
            ForEach(i => ret[idx++] = i);

            return ret;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Reverse()
        {
            if (Count < 2) return;

            var left    = Head;
            var right   = Tail;

            for (int i = 0; i < count / 2; i++)
            {
                var temp    = left.Value;
                left.Value  = right.Value;
                right.Value = temp;
                left        = left.Next;
                right       = right.Previous;
            }
        }
        public bool Contains(T value)
        {
            return FindFirstOrDefault(value) != null ? true : false;
        }
        public DoublyLinkedList<T> Where(Predicate<T> filter)
        {
            var newList = new DoublyLinkedList<T>();

            var curr = Head;

            while (curr != null)
            {
                if (filter(curr.Value))
                {
                    newList.AddLast(curr.Value);
                }

                curr = curr.Next;
            }

            return newList;
        }
        public bool RemoveFirstFound(T value)
        {
            var found = FindFirstOrDefault(value);

            if (found == null) return false;

            if (found.Previous == null)
            {
                RemoveFirst();
            }
            else if (found.Next == null)
            {
                RemoveLast();
            }
            else
            {
                found.Previous.Next = found.Next;
                found.Next.Previous = found.Previous;
                Count--;
            }

            return true;
        }
        public void RemoveAll(T value)
        {
            while (RemoveFirstFound(value)) ;
        }
        public void Clear()
        {
            Head    = null;
            Tail    = null;
            Count   = 0;
        }
        public override string ToString()
        {
            return $"{string.Join(" ", ToArray().Select(n => n.ToString()))} : Count - {Count}";
        }
        private void CheckListIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
        private IEnumerator<T> GetEnumerator()
        {
            var curr = Head;

            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }
        private ListNode<T> FindFirstOrDefault(T value)
        {
            var curr = Head;

            while (curr != null)
            {
                if (curr.Value.Equals(value)) return curr;
                curr = curr.Next;
            }

            return null;
        }
    }
}