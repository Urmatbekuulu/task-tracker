using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_tracker.Data;
using Task = task_tracker.Entities.Task;

namespace task_tracker.Services
{
    public class TaskService:ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public  async System.Threading.Tasks.Task<IEnumerable<Task>> GetTaskList()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<int> UpdateTask(Task task)
        {
            _dbContext.Tasks.Update(task);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteTask(Task task)
        {
            _dbContext.Tasks.Remove(task);
            return await _dbContext.SaveChangesAsync();
        }
    }
}