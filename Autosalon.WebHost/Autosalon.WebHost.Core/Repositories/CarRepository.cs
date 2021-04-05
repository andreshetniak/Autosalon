using Autosalon.WebHost.Core.Services;
using Autosalon.WebHost.Infrastrucure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autosalon.WebHost.Core.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private AutosalonContext dbContext;

        public CarRepository(AutosalonContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateItem(Car item)
        {
            dbContext.Car.Add(item);
            this.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            //dbContext.Entry<Car>(dbContext.Car.Find(id)).State = EntityState.Deleted;
            
            var teDelete = dbContext.Car.Where(x => x.Id == id).FirstOrDefault();
            if (teDelete != null)
            {
                dbContext.Car.Remove(teDelete);
            }
            this.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Car GetItem(int id)
        {
            return dbContext.Car.Find(id);
        }

        public IEnumerable<Car> GetItems()
        {
            return dbContext.Car.ToList();
        }

        public void SaveChanges()
        {
            var v = dbContext.ChangeTracker.Entries<Car>();
            dbContext.SaveChanges();
            
        }

        public void UpdateItem(Car car)
        {
            dbContext.Entry(car).State = EntityState.Modified;
            this.SaveChanges();
        }
    }
}
