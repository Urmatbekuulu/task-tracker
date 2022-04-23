using System;
using System.Threading.Tasks;

namespace task_tracker.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IProjectRepository Projects { get; }
        ITaskRepository Tasks { get; }
        
        Task SaveAsync();
    }
}