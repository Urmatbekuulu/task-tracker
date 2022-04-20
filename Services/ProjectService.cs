using System.Collections.Generic;
using System.Media;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_tracker.Data;
using task_tracker.Entities;

namespace task_tracker.Services
{
    public class ProjectService:IProjectService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Project>> GetProjectList()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<Project> CreateProject(Project project)
        {
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<int> UpdateProject(Project project)
        {
            _dbContext.Projects.Update(project);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProject(Project project)
        {
            if(project is not null)_dbContext.Projects.Remove(project);
            return await _dbContext.SaveChangesAsync();
        }
    }
}