using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;
        protected Repository()
        {
            models = new List<T>();
        }
        public virtual IReadOnlyCollection<T> Models => models;
        public virtual void Add(T model)
        {
            models.Add(model);
        }

        public virtual T FindByType(string type)
        {
            return models.FirstOrDefault(m => m.GetType().Name == type);
        }

        public virtual bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
