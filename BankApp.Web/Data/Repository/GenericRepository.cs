using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,new()
    {
        private readonly BankContext _bankContext;

        public GenericRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public void Create(T entity)
        {
            _bankContext.Set<T>().Add(entity);
            _bankContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _bankContext.Set<T>().Remove(entity);
            _bankContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _bankContext.Set<T>().Update(entity);
            _bankContext.SaveChanges();
        }

        public List<T> Getall()
        {
           return _bankContext.Set<T>().ToList();
        }

        public T GetbyId(int id)
        {
            return _bankContext.Set<T>().Find(id);
        }
    }
}
