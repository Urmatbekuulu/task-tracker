using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.DTOs;


namespace task_tracker.BLL.Interfaces
{
    public interface ITaskService
    {
        //business operation interfaces with tasks

        Task<TaskDTO> CreateTaskAsync(TaskDTO taskDto);
        Task UpdateTaskAsync(TaskDTO taskDto);
        Task DeleteTaskAsync(TaskDTO taskDto);
        Task<TaskDTO> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskDTO>> GetProjectTasksAsync(int projectId);
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<IEnumerable<TaskDTO>> FindTasksAsync(Func<TaskDTO, bool> predicate);
    }
}