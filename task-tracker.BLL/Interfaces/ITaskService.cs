using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace task_tracker.BLL.Interfaces
{
    public interface ITaskService
    {
        //business operation interfaces with tasks

        Task<DAL.Entities.Task> CreateTaskAsync(DAL.Entities.Task taskDto);
        Task UpdateTaskAsync(DAL.Entities.Task taskDto);
        Task DeleteTaskAsync(DAL.Entities.Task taskDto);
        Task<DAL.Entities.Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<DAL.Entities.Task>> GetProjectTasksAsync(int projectId);
        Task<IEnumerable<DAL.Entities.Task>> GetAllTasksAsync();
        Task<IEnumerable<DAL.Entities.Task>> FindTasksAsync(Func<DAL.Entities.Task, bool> predicate);
    }
}