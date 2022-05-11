using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Identity;

namespace task_tracker.ApiEndpoints.Registration
{
    public class Register:EndpointBaseAsync.WithRequest<Request.Register>.WithResult<ActionResult<Response.Register>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public Register(UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost("api/register")]
        [SwaggerOperation( 
            Summary = "Register user",
            Description = "Registers user",
            OperationId = "Auth.Register",
            Tags = new[] { "Register" })]
        public override async Task<ActionResult<Response.Register>> HandleAsync(Request.Register request, CancellationToken cancellationToken = new CancellationToken())
        {
            if ((await IsUserExists(request))) return BadRequest("User already exists");

            var user = _mapper.Map<ApplicationUser>(request);

            var result = await _userManager.CreateAsync(user);
            
            if (!result.Succeeded) return BadRequest("Something was wrong");

            await _userManager.AddToRoleAsync(user:user, role:RoleConstants.EMPLOYEE);

            var verificationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //send email to confirm email address

            return Ok(new Response.Register(){Message = "Registered Successfully"});
        }

        private async Task<bool> IsUserExists(Request.Register request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return false;
            return true;
        }
    }
}