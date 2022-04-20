

using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project;
using task_tracker.ApiEndpoints.Project.Requests;
using task_tracker.Services;

namespace task_tracker.ApiEndpoints
{
    public class UpdateProject:EndpointBaseAsync.WithRequest<Request.UpdateProject>.WithResult<Response.UpdatedResul>
    {
        private readonly IProjectService _projectService;

        public UpdateProject(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpPost("api/project/update")]
        [SwaggerOperation(
            Summary = "Updates project",
            Description = "Updates existing project",
            OperationId = "Projects.Updated",
            Tags = new[] { "Projects" })
        ]
        public override Task<Response.UpdatedResul> HandleAsync(Request.UpdateProject request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}