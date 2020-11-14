using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Hierarchy
{
    public class Node<T>
    {
        public T        Value   { get; private set; }
        public Node<T>  Parent  { get; set; }
        public List<Node<T>> children { get; private set; }

        public Node(T value, Node<T> parent)
        {
            this.Value  = value;
            this.Parent = parent;
            children = new List<Node<T>>();
        }

    }
}
