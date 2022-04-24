using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task_tracker.DAL.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Find(Func<T, Boolean> predicate);
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(int id);
        
    }
}