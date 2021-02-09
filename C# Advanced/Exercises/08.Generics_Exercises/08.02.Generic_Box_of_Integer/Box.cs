using System.Text;

namespace _08._01.Generic_Box_of_String
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
            var sb = new StringBuilder();
            sb.Append(item.GetType().FullName.ToString()).Append(": ");
            sb.Append(item.ToString());

            return sb.ToString();
        }
    }
}
