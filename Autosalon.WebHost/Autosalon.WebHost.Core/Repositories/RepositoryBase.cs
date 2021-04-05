using Autosalon.WebHost.Core.Services;
using Autosalon.WebHost.Infrastrucure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.WebHost.Core.Repositories
{
    class RepositoryBase<T> : IRepository<T> where T : class
    {
        private AutosalonContext dbContext;

        public RepositoryBase(AutosalonContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateItem(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
