using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;

        public ViewDetail(IProjectService projectService,ITaskService taskService)
        {
            _projectService = projectService;
            _taskService = taskService;
        }
        [HttpGet("api/project/view/{id:int}")]
        [SwaggerOperation(
            Summary = "view project detail",
            Description = "shows project all detals with tasks",
            OperationId = "Projects.Delete",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            if (id < 1) return BadRequest("Id is not permittable");
            var project =await _projectService.GetProjectByIdAsync(id);
            return Ok(project);
        }
    }
}