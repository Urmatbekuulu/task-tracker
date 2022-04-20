using System.Collections.Generic;
using System.Threading.Tasks;
using Task = task_tracker.Entities.Task;

namespace task_tracker.Services
{
    public class TaskService:ITaskService
    {
        public System.Threading.Tasks.Task<IEnumerable<Task>> GetTaskList()
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateTask(Task task)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteTask(Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}