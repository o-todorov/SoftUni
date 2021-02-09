
namespace Generic_Swap_Method_Ints
{
    public class Box<T>
    {
        private readonly T item;
        public Box(T item)
        {
            this.item = item;
        }
        public override string ToString()
        {
            return $"{item.GetType().FullName.ToString()}: {item.ToString()}";
        }
    }
}
