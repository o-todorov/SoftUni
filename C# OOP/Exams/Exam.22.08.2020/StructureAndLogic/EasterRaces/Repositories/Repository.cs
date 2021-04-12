using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly List<T> collection;

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
            return collection;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return collection.Remove(model);
        }
    }
}
