using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task_tracker.DAL.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteByIdAsync(int id);
        
    }
}