using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Interfaces;

namespace task_tracker.ApiEndpoints.Auth
{
    public class Authenticate : EndpointBaseAsync
        .WithRequest<Request
            .Login>.WithResult<ActionResult<Response.Login>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;

        public Authenticate(
            SignInManager<DAL.Entities.ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtFactory jwtFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }


        [HttpPost("api/login")]
        [SwaggerOperation(
            Summary = "Authenticates user",
            Description = "Authenticates user",
            OperationId = "Auth.Login",
            Tags = new[] { "Login" })]
        public override async Task<ActionResult<Response.Login>> HandleAsync(Request.Login request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Empty user");

            var user = await _userManager.FindByEmailAsync(request.Email);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!result.Succeeded) return BadRequest("Wrong email or password");

            var (token, expires) = await _jwtFactory.CreateTokenAsync(user.Id, user.Email);

            return new Response.Login()
            {
                Username = user.Email,
                UserId = user.Id,
                JwtToken = token,
                JwtExpires = expires

            };
        }
    }
}