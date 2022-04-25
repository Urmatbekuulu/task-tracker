using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Interfaces;
using task_tracker.DAL.Entities;
using Task = System.Threading.Tasks.Task;


namespace task_tracker.BLL.Services
{
    public class TaskService:ITaskService
    {
        private readonly IUnitOfWork _dataLayer;

        public TaskService(IUnitOfWork dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public Task<DAL.Entities.Task> CreateTaskAsync(DAL.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskAsync(DAL.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DAL.Entities.Task> GetTaskByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DAL.Entities.Task>> GetProjectTasksAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DAL.Entities.Task>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DAL.Entities.Task>> FindTasksAsync(Func<DAL.Entities.Task, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}