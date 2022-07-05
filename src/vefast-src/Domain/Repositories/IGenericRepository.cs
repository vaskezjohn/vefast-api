using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByID(Guid id);
        Task<T> GetByIDAsync(Guid id);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        int Save();
        Task<int> SaveAsync();
    }
}
