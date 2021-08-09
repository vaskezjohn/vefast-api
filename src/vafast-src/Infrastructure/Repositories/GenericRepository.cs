using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vafast_src.Domain.Repositories;

namespace vafast_src.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly VafastDataContext _context;

        public GenericRepository(VafastDataContext context)
        {
            this._context = context;
        }

        public VafastDataContext DataContext
        {
            get
            {
                return _context;
            }
        }

        protected DbSet<T> GetDbSet()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetDbSet().AsQueryable();
        }

        public virtual T GetByID(Guid id)
        {
            return GetDbSet().Find(id);
        }

        public virtual async Task<T> GetByIDAsync(Guid id)
        {
            return await GetDbSet().FindAsync(id);
        }

        public void Add(T obj)
        {
            GetDbSet().Add(obj);
        }

        public void Update(T obj)
        {
            GetDbSet().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                GetDbSet().Attach(obj);
            }

            GetDbSet().Remove(obj);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
