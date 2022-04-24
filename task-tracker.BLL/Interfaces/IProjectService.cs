using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace task_tracker.BLL.Interfaces
{
    public interface IProjectService
    {   
        //business operation interfaces with projects
        
        Task<Project> CreateProjectAsync(Project projectDto);
        Task UpdateProjectAsync(Project projectDto);
        Task DeleteProjectByIdAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<IEnumerable<Project>> FindProjectsAsync(Func<Project,bool> predicate);


    }
}