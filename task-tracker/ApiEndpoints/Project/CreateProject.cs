using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;

using task_tracker.Services;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject : EndpointBaseAsync.WithRequest<Request.CreateProject>.WithResult<
        ActionResult<Response.CreateProjectResponse>>
    {

        public CreateProject()
        {
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
                var result = await _projectService.CreateProject(new Entities.Project()
                {
                    Name = request.Name,
                    CompletionDate = request.CompletionDate,
                    StartDate = request.StartDate,
                    Priority = request.Priority,
                    ProjectStatus = request.ProjectStatus
                });
                return Ok(new Response.CreateProjectResponse()
                {
                    CompletionDate = result.CompletionDate,
                    Id = result.Id,
                    Name = result.Name,
                    Priority = result.Priority,
                    ProjectStatus = result.ProjectStatus,
                    StartDate = result.StartDate
                });
            }

            return BadRequest("Something was wrong");
        }
    }
}