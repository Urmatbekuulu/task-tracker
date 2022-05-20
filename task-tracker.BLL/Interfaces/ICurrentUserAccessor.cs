using System.Threading.Tasks;
using task_tracker.DAL.Entities;

namespace task_tracker.BLL.Interfaces
{
    public interface ICurrentUserAccessor
    {
        string GetCurrentUserId();
        
        Task<ApplicationUser> GetCurrentUserAsync();

        ApplicationUser GetCurrentUser();

        




    }
}