using System;

namespace CustomDoublyLinkedList
{
    class LinkedList
    {
        private int count = 0;
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void AddHead(int value)
        {
            Node node = new Node(value);
            count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next       = Head;
            Head.Previous   = node;
            Head            = node;

        }
        public void AddTail(int value)
        {
            Node node = new Node(value);
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next   = node;
            Tail        = node;

        }
        public int RemoveFirst()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int ret = Head.Value;
            Head = Head.Next;
            count--;

            if (count == 0)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }

            return ret;
        }
        public int RemoveLast()
        { 
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int ret = Tail.Value;
            Tail = Tail.Previous;
            count--;

            if (count == 0)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }

            return ret;
        }
        public void ForEach(Action<int> doAction)
        {
            Node curr = Head;

            while (curr != null)
            {
                doAction(curr.Value);
                curr = curr.Next;
            }
        }
        public int[] ToArray()
        {
            int[] ret = new int[count];
            int idx = 0;
            ForEach(i => ret[idx++] = i);

            return ret;
        }
        public void Reverse()
        {
            if (count < 2) return;

            Node left = Head;
            Node right = Tail;

            for (int i = 0; i < count / 2; i++)
            {
                var temp    = left.Value;
                left.Value  = right.Value;
                right.Value = temp;
                left        = left.Next;
                right       = right.Previous;
            }
        }
        public bool Exist(int value)
        {
            return FindFirstOrDefault(value) != null ? true : false;
        }
        public Node FindFirstOrDefault(int value)
        {
            Node curr = Head;

            while (curr != null)
            {
                if (curr.Value == value) return curr;
                curr = curr.Next;
            }

            return null;
        }
        public LinkedList Where(Predicate<int> filter)
        {
            LinkedList newList = new LinkedList();

            Node curr = Head;

            while (curr != null)
            {
                if (filter(curr.Value)) 
                {
                    newList.AddTail(curr.Value);
                }
                curr = curr.Next;
            }

            return newList;
        }
        public bool RemoveFirstFound(int value)
        {
            Node found = FindFirstOrDefault(value);

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
                count--;
            }

            return true;
        }
        public void RemoveAll(int value)
        {
            while (RemoveFirstFound(value)) { };
        }
        public override string ToString()
        {
            return $"{string.Join(" ", ToArray())} : Count - {count}";
        }
    }
}
