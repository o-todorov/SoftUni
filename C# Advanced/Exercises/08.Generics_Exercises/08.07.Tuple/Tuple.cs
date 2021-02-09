using System;

namespace TupleTest
{
    class MyTuple<T, V>
    {
        public MyTuple(T item1, V item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T item1 { get; }
        public V item2 { get; }
    }
}
