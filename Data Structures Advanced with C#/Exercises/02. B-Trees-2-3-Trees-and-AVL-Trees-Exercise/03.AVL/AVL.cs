
namespace _03.AVL
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void Delete(T v)
        {
            this.Root = Delete(this.Root, v);
        }

        public void DeleteMin()
        {
            if (this.Root == null) return;

            T min = FindMin(this.Root).Value;

            this.Root = Delete(this.Root, min);
        }

        private Node<T> Delete(Node<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            // Found Value To Delete
            else if (value.CompareTo(node.Value) == 0)
            {
                // If Exists Left Branch Only
                if (node.Left != null && node.Right == null)
                {
                    return node.Left;
                }
                // If Exists Right Branch Only
                else if (node.Right != null && node.Left == null)
                {
                    return node.Right;
                }
                // If Exist Both Branches. Finds The Branch To Pull To The Top
                // Depend On Balance Factor
                else if (node.Right != null && node.Left != null)
                {

                    Node<T> newNode = null;
                    int BF = Height(node.Left) - Height(node.Right);

                    if (BF >= 0)
                    {
                        if (node.Left.Right != null)
                        {
                            T max = FindEndDeleteLeftMax(ref node.Left);
                            newNode = new Node<T>(max);
                            newNode.Left = node.Left;
                        }
                        else
                        {
                            newNode = node.Left;
                        }

                        newNode.Right = node.Right;
                    }
                    else
                    {
                        if (node.Right.Left != null)
                        {
                            T min = FindEndDeleteRightMin(ref node.Right);
                            newNode = new Node<T>(min);
                            newNode.Right = node.Right;
                        }
                        else
                        {
                            newNode = node.Right;
                        }

                        newNode.Left = node.Left;
                    }

                    UpdateHeight(newNode);

                    return newNode;
                }
                // If No Branches Just Set To Nulll
                else
                {
                    return null;
                }
            }
            else  // Reveal The Tree To Find the Value - Left and Rifht
            {
                if (value.CompareTo(node.Value) < 0)
                {
                    node.Left = Delete(node.Left, value);
                }
                else
                {
                    node.Right = Delete(node.Right, value);
                }

                node = Balance(node);
                //Balance(node);
                UpdateHeight(node);

                return node;
            }
        }

        private T FindEndDeleteRightMin(ref Node<T> node)
        {
            while (node.Left.Left != null)
            {
                node = node.Left;

            }

            T min = node.Left.Value;

            node.Left = null;
            UpdateHeight(node);
            node = Balance(node);

            return min;
        }

        private  T FindEndDeleteLeftMax(ref Node<T> node)
        {

            while (node.Right.Right != null)
            {
                node = node.Right;

            }

            T max = node.Right.Value;

            node.Right = null;
            UpdateHeight(node);
            node = Balance(node);

            return max;
        }

        private Node<T> FindMin(Node<T> node)
        {
            if (node == null) return null;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private Node<T> Balance(Node<T> node)
        {
            var balance = Height(node.Left) - Height(node.Right);
            if (balance > 1)
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
                UpdateHeight(node);
            }
            else if (balance < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
                UpdateHeight(node);
            }

            return node;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }
    }
}
