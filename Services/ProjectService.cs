using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.Entities;

namespace task_tracker.Services
{
    public class ProjectService:IProjectService
    {
        public Task<IEnumerable<Project>> GetProjectList()
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetProjectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> CreateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateProject(Project project)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteProject(Project project)
        {
            throw new System.NotImplementedException();
        }
    }
}