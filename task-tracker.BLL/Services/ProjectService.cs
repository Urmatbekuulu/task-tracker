using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace task_tracker.BLL.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IUnitOfWork _dataLayer;
       

        public ProjectService(IUnitOfWork dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            var result =await _dataLayer.Projects.Create(project);
            await _dataLayer.SaveAsync();
            return result;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _dataLayer.Projects.Update(project);
            await _dataLayer.SaveAsync();
        }

        public async Task DeleteProjectByIdAsync(int id)
        {
            await _dataLayer.Projects.Delete(id);
            await _dataLayer.SaveAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = _dataLayer.Projects.GetById(id);
            return await project;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects = await _dataLayer.Projects.GetAll();
          
            return projects;
        }

        public async Task<IEnumerable<Project>> FindProjectsAsync(Func<Project, bool> predicate)
        {
            var result = await _dataLayer.Projects.Find(predicate);
            return result;
        }
    }
}