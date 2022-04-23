using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;
using task_tracker.BLL.DTOs;
using task_tracker.BLL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject : EndpointBaseAsync.WithRequest<Request.CreateProject>.WithResult<
        ActionResult<Response.CreateProjectResponse>>
    {
        private readonly IProjectService _projectService;

        public CreateProject(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpPost("api/project/create")]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "creates a new project",
            OperationId = "Projects.Create",
            Tags = new[] { "Projects" })
        ]
        public override async  Task<ActionResult<Response.CreateProjectResponse>> HandleAsync(Request.CreateProject request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (ModelState.IsValid)
            {
                var result = await _projectService.CreateProjectAsync(new ProjectDTO()
                {
                    
                });
                return Ok();
            }

            return BadRequest("Something was wrong");
        }
    
    }
}