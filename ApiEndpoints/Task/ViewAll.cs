using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.Services;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class ViewAll:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IEnumerable<Task.Response.ViewAllTask>>>
    {
        private readonly ITaskService _taskService;

        public ViewAll(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("api/task/view")]
        [SwaggerOperation(
            Summary = "Get all Tasks",
            Description = "Get all tasks",
            OperationId = "Task.ViewAll",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<IEnumerable<Task.Response.ViewAllTask>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await _taskService.GetTaskList();
            return Ok(result.Select(t => new Task.Response.ViewAllTask()
            {
                Name = t.Name,
                Id = t.Id,
                ProjectId = t.Id,
                TaskStatus = t.TaskStatus.ToString()

            }).ToList());
        }
    }
}