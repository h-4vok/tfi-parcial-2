using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzmanflix.DAL
{
    public abstract class BaseDAL<T, Y>
    {
        protected IList<T> persistance = new List<T>();

        protected abstract Func<T, Y> GetIdClosure { get; }

        private bool CompareModels(T obj1, T obj2) => Object.Equals(this.GetIdClosure(obj1), this.GetIdClosure(obj2));

        public void Create(T model) => this.persistance.Add(model);

        public void Update(T model)
        {
            var foundModel = this.persistance.FirstOrDefault(x => this.CompareModels(x, model));

            if (foundModel == null)
            {
                this.Create(model);
                return;
            }

            this.persistance.Remove(foundModel);
            this.persistance.Add(model);
        }

        public void Delete(T model)
        {
            var foundModel = this.persistance.FirstOrDefault(x => this.CompareModels(x, model));

            if (foundModel == null) return;

            this.persistance.Remove(foundModel);
        }

        public IList<T> Get()
        {
            return this.persistance.ToList();
        }

        public T Get(Y id)
        {
            return this.persistance.FirstOrDefault(x => Object.Equals(this.GetIdClosure(x), id));
        }

    }
}
