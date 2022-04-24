using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class ViewAll:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IEnumerable<Response.List>>>
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
        public override async Task<ActionResult<IEnumerable<Response.List>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await _taskService.GetAllTasksAsync();
            return Ok();
        }
    }
}