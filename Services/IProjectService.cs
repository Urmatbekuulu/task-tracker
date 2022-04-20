using System.Collections.Generic;
using System.Threading.Tasks;
using task_tracker.Entities;

namespace task_tracker.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectList();
        Task<Project> GetProjectById(int id);
        Task<Project> CreateProject(Project project);
        Task<int> UpdateProject(Project project);
        Task<int> DeleteProject(Project project);

    }
}