using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.DTOs;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Interfaces;

namespace task_tracker.BLL.Services
{
    public class TaskService:ITaskService
    {
        private readonly IUnitOfWork _dataLayer;

        public TaskService(IUnitOfWork dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public Task<TaskDTO> CreateTaskAsync(TaskDTO taskDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskAsync(TaskDTO taskDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(TaskDTO taskDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDTO> GetTaskByIdAsync(TaskDTO taskDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDTO>> GetProjectTasksAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDTO>> FindTasksAsync(Func<TaskDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}