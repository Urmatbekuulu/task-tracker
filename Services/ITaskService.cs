using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.Entities;
using Task = task_tracker.Entities.Task;

namespace task_tracker.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetTaskList();
        Task<Task> GetTaskById(int id);
        Task<Task> CreateTask(Task task);
        Task<int> UpdateTask(Task task);
        Task<int> DeleteTask(Task task);
        
    }
}