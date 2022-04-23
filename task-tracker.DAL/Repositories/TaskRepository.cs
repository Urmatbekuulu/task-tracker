using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using task_tracker.DAL.Data;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Interfaces;

namespace task_tracker.DAL.Repositories
{
    public class TaskRepository:GenericRepository<Task>,ITaskRepository
    {

        public TaskRepository(ApplicationDbContext dbContext,ILogger logger):base(dbContext,logger)
        {
           
        }

    }
}