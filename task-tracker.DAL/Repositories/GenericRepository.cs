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
        private readonly ILogger _logger;
        private DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context,ILogger logger)
        {
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Find(Func<T,bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public virtual async Task Create(T item)
        {
            await dbSet.AddAsync(item);
        }

        public virtual async Task Update(T item)
        {
             dbSet.Update(item);
        }

        public virtual async Task Delete(int id)
        {
            var result = await GetById(id);
            dbSet.Remove(result);
        }
    }
}