using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace task_tracker.DAL.Configuration
{
    public class JwtAuthorizeAttribute:AuthorizeAttribute
    {
        public JwtAuthorizeAttribute(params string[] roles)
        {
            AuthenticationSchemes = "Bearer";
            Roles = roles.Length > 0 ? string.Join(",", roles) : Roles;

        }
        
    }
}