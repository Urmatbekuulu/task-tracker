using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.Services;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class UpdateTask:EndpointBaseAsync.WithRequest<Task.Request.UpdateTask>.WithResult<ActionResult<int>>
    {
        private readonly ITaskService _taskService;

        public UpdateTask(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost("api/task/update")]
        [SwaggerOperation(
            Summary = "Update Task",
            Description = "Updates existing task",
            OperationId = "Task.Update",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<int>> HandleAsync(Task.Request.UpdateTask request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}