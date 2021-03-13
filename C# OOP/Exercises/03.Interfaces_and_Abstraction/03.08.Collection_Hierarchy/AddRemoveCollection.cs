namespace CollectionHierarchy
{
    public class AddRemoveCollection<T> :AddCollection<T>, IAddRemoveCollection<T>
    {
        public int Add(T toAdd)
        {
            for (int i = count; i >0; i--)
            {
                collection[i] = collection[i - 1];
            }

            collection[0] = toAdd;
            count++;
            return 0;
        }
        public virtual T Remove()
        {
            return collection[count-- - 1];
        }
    }
}
