using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.DTOs;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Interfaces;
using Task = task_tracker.DAL.Entities.Task;

namespace task_tracker.BLL.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IUnitOfWork _dataLayer;

        public ProjectService(IUnitOfWork dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProjectAsync(ProjectDTO projectDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectDTO>> FindProjectsAsync(Func<ProjectDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}