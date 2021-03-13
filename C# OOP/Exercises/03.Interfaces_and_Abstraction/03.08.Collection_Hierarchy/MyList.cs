namespace CollectionHierarchy
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public override T Remove()
        {
            T ret = collection[0];

            for (int i = 0; i < count; i++)
            {
                collection[i] = collection[i + 1];
            }

            count--;
            return ret;
        }
        public int Used => count;
    }
}
