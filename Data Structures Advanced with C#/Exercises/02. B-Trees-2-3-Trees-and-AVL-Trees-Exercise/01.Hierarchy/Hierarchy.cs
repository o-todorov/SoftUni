namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> dict = new Dictionary<T, Node<T>>();

        public Hierarchy(T defaultRootValue)
        {
            this.root = new Node<T>(defaultRootValue, null);
            dict[this.root.Value] = this.root;
            //Count = 1;
        }

        public int Count { get { return dict.Count; } }

        public void Add(T element, T child)
        {
            Node<T> parent = FindElementOrRaiseError(element);

            if (this.Contains(child))
            {
                throw new ArgumentException();
            }
            else
            {
                var node = new Node<T>(child, parent);
                parent.children.Add(node);
                dict[child] = node;
                //Count++;
            }
        }

        private Node<T> FindElementOrRaiseError(T element)
        {
            if (!dict.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            return dict[element];

        }

        public void Remove(T element)
        {
            Node<T> node = FindElementOrRaiseError(element);

            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }


            node.children.ForEach(ch => ch.Parent = node.Parent);
            node.Parent.children.AddRange(node.children);
            node.Parent.children.Remove(node);
            dict.Remove(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            Node<T> node = FindElementOrRaiseError(element);

            return node.children.Select(ch => ch.Value);
        }

        public T GetParent(T element)
        {
            var node = FindElementOrRaiseError(element);

            return (node.Parent == null) ? default : node.Parent.Value;
        }

        public bool Contains(T element)
        {
            return dict.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            return dict.Keys.Where(k => other.Contains(k));
        }

        public IEnumerator<T> GetEnumerator()
        {
            var list = new Queue<Node<T>>();

            list.Enqueue(this.root);

            while (list.Count > 0)
            {
                var node = list.Dequeue();

                yield return node.Value;

                foreach (var child in node.children)
                {
                    list.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}