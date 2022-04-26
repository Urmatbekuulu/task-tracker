using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using task_tracker.DAL.Data;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace task_tracker.DAL.Repositories
{
    public class ProjectRepository:GenericRepository<Project>,IProjectRepository,IGenericRepository<Project>
    {
        public ProjectRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }
        

       
    }
}