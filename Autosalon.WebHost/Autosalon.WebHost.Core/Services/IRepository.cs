using System;
using System.Collections.Generic;

namespace Autosalon.WebHost.Core.Services
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        void CreateItem(T item);
        void DeleteItem(int id);
        void UpdateItem(T item);
        void SaveChanges();
    }
}
