
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Task.Response.ViewDetail>>
    {
        private readonly ITaskService _taskService;

        public ViewDetail(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("api/task/view/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "detailed task",
            Description = "all information about task",
            OperationId = "Task.ViewDetail",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<Task.Response.ViewDetail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
           
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task != null)
                return Ok(new Task.Response.ViewDetail()
                {
                    // Id   = task.Id,
                    // Name = task.Name,
                    // Description = task.Description,
                    // Priority = task.Priority,
                    // ProjectId = task.ProjectId,
                    // TaskStatus = task.TaskStatus.ToString()
                });
            return BadRequest("Something was wrong");
        }
    }
}