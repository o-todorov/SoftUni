namespace _02.Two_Three
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public TwoThreeTree()
        {
            this.root = null;
        }

        public void Insert(T key)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(key);
            }
            else
            {
                this.root = InsertKeyToNode(this.root, key);
            }
        }

        private TreeNode<T> InsertKeyToNode(TreeNode<T> node, T newValue)
        {
            if (node == null)
            {
                return node = new TreeNode<T>(newValue);
            }

            TreeNode<T> inserted;

            if (node.IsLeaf())
            {
                inserted = AddKeyToLeafNode(node, newValue);

                if (inserted == node)
                {
                    return node;
                }
                else
                {
                    return inserted;
                }
            }
            else
            {
                if (newValue.CompareTo(node.LeftKey) < 0)
                {
                    inserted = InsertKeyToNode(node.LeftChild, newValue);
                    if (inserted == node.LeftChild) return node;
                }
                else if (node.IsTwoNode() || newValue.CompareTo(node.RightKey) < 0)
                {
                    inserted = InsertKeyToNode(node.MiddleChild, newValue);
                    if (inserted == node.MiddleChild) return node;
                }
                else
                {
                    inserted = InsertKeyToNode(node.RightChild, newValue);
                    if (inserted == node.RightChild) return node;
                }

                return InsertNodeToNode(node, inserted);
            }
        }

        private TreeNode<T> InsertNodeToNode(TreeNode<T> node, TreeNode<T> toAdd)
        {
            if (node.IsTwoNode())
            {
                if (toAdd.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    node.RightKey   = node.LeftKey;
                    node.LeftKey    = toAdd.LeftKey;


                    node.RightChild     = node.MiddleChild;
                    node.MiddleChild    = toAdd.MiddleChild;
                    node.LeftChild      = toAdd.LeftChild;
                }
                else
                {
                    node.RightKey       = toAdd.LeftKey;
                    node.MiddleChild    = toAdd.LeftChild;
                    node.RightChild     = toAdd.MiddleChild;
                }

                return node;
            }
            else
            {
                if (toAdd.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    var right = new TreeNode<T>(node.RightKey);
                    right.LeftChild = node.MiddleChild;
                    right.MiddleChild = node.RightChild;
                    node.RightKey = default;
                    node.LeftChild = toAdd;
                    node.MiddleChild = right;
                    node.RightChild = default;

                    return node;
                }
                else if (toAdd.LeftKey.CompareTo(node.RightKey) < 0)
                {
                    var right = new TreeNode<T>(node.RightKey);
                    right.LeftChild = toAdd.MiddleChild;
                    right.MiddleChild = node.RightChild;

                    node.RightKey = default;
                    node.MiddleChild = toAdd.LeftChild;
                    node.RightChild = default;

                    toAdd.LeftChild = node;
                    toAdd.MiddleChild = right;

                    return toAdd;
                }
                else
                {
                    var mid = new TreeNode<T>(node.RightKey);
                    mid.LeftChild = node;
                    mid.MiddleChild = toAdd;

                    node.RightKey = default;

                    return mid;
                }
            }

        }

        //private TreeNode<T> SetToChild(TreeNode<T> child, T newValue)
        //{
        //    if (child == null)
        //    {
        //        return child = new TreeNode<T>(newValue);
        //    }
        //    else
        //    {
        //        return InsertKeyToNode(child, newValue);
        //    }
        //}

        private TreeNode<T> AddKeyToLeafNode(TreeNode<T> node, T newValue)
        {
            if (newValue.CompareTo(node.LeftKey) < 0) 
            {
                swapNodeKeys( ref node.LeftKey,ref newValue);
            }

            if (node.IsTwoNode())
            {
                node.RightKey = newValue;
                return node;
            }
            else
            {
                if (newValue.CompareTo(node.RightKey) < 0)
                {
                    swapNodeKeys(ref node.RightKey, ref newValue);
                }

                var retNode = new TreeNode<T>(node.RightKey);
                
                retNode.LeftChild = node;
                node.RightKey = default;
                retNode.MiddleChild = new TreeNode<T>(newValue);

                return retNode;
            }

        }

        private void swapNodeKeys(ref T leftKey,ref  T newValue)
        {
            var next = leftKey;
            leftKey = newValue;
            newValue = next;
        }


        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
