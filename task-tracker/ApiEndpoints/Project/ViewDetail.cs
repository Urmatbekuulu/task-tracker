using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;
using task_tracker.Services;

namespace task_tracker.ApiEndpoints.Project
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.ViewDetailly>>
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
        public override async Task<ActionResult<Response.ViewDetailly>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            if (id < 1) return BadRequest("Id is not permittable");
            var project =await _projectService.GetProjectById(id);
           if (project is not null)
           {
               return Ok(new Response.ViewDetailly
               {
                   Name = project.Name,
                   Id = project.Id,
                   Priority = project.Priority,
                   CompletionDate = project.CompletionDate,
                   StartDate = project.StartDate,
                   ProjectStatus = project.ProjectStatus.ToString(),
                   Tasks = _taskService.GetTaskList()
                       .Result
                       .Where(t=>t.ProjectId==id)
                       .ToList()
               });
           }

           return BadRequest("Something went wrong");
        }
    }
}