using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Entities;

namespace task_tracker.BLL.Services
{
    public class CurrentUserAccessor:ICurrentUserAccessor
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _dbContext;

        public CurrentUserAccessor(IHttpContextAccessor contextAccessor, ApplicationDbContext dbContext)
        {
            _contextAccessor = contextAccessor;
            _dbContext = dbContext;
        }

        public string GetCurrentUserId()
        {
            return _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type is JwtRegisteredClaimNames.Sub or ClaimTypes.NameIdentifier).Value;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _dbContext.Employees.FindAsync(GetCurrentUserId());
        }

        public ApplicationUser GetCurrentUser()
        {
            return _dbContext.Employees.Find(GetCurrentUserId());
        }

        
    }
}