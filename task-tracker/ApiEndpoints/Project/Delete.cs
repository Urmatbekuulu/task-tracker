using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Project
{
    public class DeleteProject:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<int>>
    {
        private readonly IProjectService _projectService;

        public DeleteProject(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpDelete("api/project/delete/{id:int}")]
        [SwaggerOperation(
            Summary = "Delete project",
            Description = "Deletes project by id",
            OperationId = "Projects.Delete",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<int>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            
            if(id<1) return BadRequest("Something was wrong");
            
            _projectService.DeleteProjectByIdAsync(id);
          
            return Ok();
            
        }
    }
}