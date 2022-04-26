using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;

namespace task_tracker.DAL.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Func<T,bool> predicate)
        {
           return dbSet.Where(predicate);
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            return  (await dbSet.AddAsync(item)).Entity;
        }

        public virtual async Task UpdateAsync(T item)
        {
             dbSet.Update(item);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var result = await GetByIdAsync(id);
            dbSet.Remove(result);
        }
    }
}