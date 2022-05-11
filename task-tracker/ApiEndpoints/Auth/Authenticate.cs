using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Entities;

namespace task_tracker.ApiEndpoints.Auth
{
    public class Authenticate:EndpointBaseAsync
        .WithRequest<Request
            .Login>.WithResult<ActionResult<Response.Login>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public Authenticate(SignInManager<DAL.Entities.ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost("api/login")]
        [SwaggerOperation( 
            Summary = "Authenticates user",
            Description = "Authenticates user",
            OperationId = "Auth.Login",
            Tags = new[] { "Login" })]
        public override async Task<ActionResult<Response.Login>> HandleAsync(Request.Login request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}