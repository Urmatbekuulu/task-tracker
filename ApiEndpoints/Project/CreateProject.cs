using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject:EndpointBaseAsync.WithRequest<Request.CreateProject>.WithResult<Response.CreateProjectResponse>
    {
        
        [HttpPost("api/project/create")]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "creates a new project",
            OperationId = "Projects.Create",
            Tags = new[] { "Projects" })
        ]
        public override async Task<Response.CreateProjectResponse> HandleAsync(Request.CreateProject request, CancellationToken cancellationToken = new CancellationToken())
        {
            return new Response.CreateProjectResponse {Name = request.Name};
        }
    }
}