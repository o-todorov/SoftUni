
namespace CustomDoublyLinkedList
{
    class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
        public ListNode<T> Previous { get; set; }
        public override string ToString() => Value.ToString();
    }
}
