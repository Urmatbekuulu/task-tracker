using System;
using Microsoft.Extensions.Logging;
using task_tracker.DAL.Data;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Enums;
using task_tracker.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace task_tracker.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        
        public IProjectRepository Projects { get; }
        public ITaskRepository Tasks { get; }
        
        public EFUnitOfWork(ApplicationDbContext dbContext,ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");

            Projects = new ProjectRepository(dbContext:dbContext,logger:_logger);
            Tasks = new TaskRepository(dbContext: dbContext, logger: _logger);
        }
        
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}