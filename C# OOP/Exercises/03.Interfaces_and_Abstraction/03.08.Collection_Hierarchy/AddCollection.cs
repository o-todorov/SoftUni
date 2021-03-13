namespace CollectionHierarchy
{
    public class AddCollection<T> : IAddCollection<T>
    {
        protected T[] collection;
        protected int count;
        public AddCollection()
        {
            collection = new T[100];
            count = 0;
        }

        public virtual int Add(T toAdd)
        {
            collection[count] = toAdd;
            return count++;
        }
    }
}
