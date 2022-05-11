using Microsoft.AspNetCore.Identity;

namespace task_tracker.ApiEndpoints.Auth
{
    public class Authenticate
    {
        public Authenticate(SignInManager<DAL.Entities.ApplicationUser> signInManager)
        {
            
        }
        
    }
}