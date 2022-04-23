using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.DTOs;
using task_tracker.DAL.Enums;
using Task = task_tracker.DAL.Entities.Task;

namespace task_tracker.BLL.Interfaces
{
    public interface IProjectService
    {   
        //business operation interfaces with projects
        
        Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto);
        Task UpdateProjectAsync(ProjectDTO projectDto);
        Task DeleteProjectByIdAsync(int id);
        Task<ProjectDTO> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectDTO>> GetProjectsAsync();
        Task<IEnumerable<ProjectDTO>> FindProjectsAsync(Func<ProjectDTO,bool> predicate);


    }
}