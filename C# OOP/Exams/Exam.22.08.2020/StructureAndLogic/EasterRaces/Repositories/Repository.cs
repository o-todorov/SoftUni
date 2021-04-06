using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> collection;

        public Repository()
        {
            this.collection = new List<T>();
        }

        public void Add(T model)
        {
            collection.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            var list = collection.ToImmutableList();
            return list;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return collection.Remove(model);
        }
    }
}
