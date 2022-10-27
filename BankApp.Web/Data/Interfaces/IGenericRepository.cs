using BankApp.Web.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class,new()
    {
        public void Create(T entity);

        public void Remove(T entity);

        public void Update(T entity);

        public List<T> Getall();

        public T GetbyId(int id);
        IQueryable<T> GetQueryable();
    }
}
