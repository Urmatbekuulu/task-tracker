using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class UpdateTask:EndpointBaseAsync.WithRequest<Request.Update>.WithResult<ActionResult<Response.Update>>
    {
        private readonly ITaskService _taskService;

        public UpdateTask(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPut("api/task/update")]
        [SwaggerOperation(
            Summary = "Update Task",
            Description = "Updates existing task",
            OperationId = "Task.Update",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<Response.Update>> HandleAsync(Request.Update request, CancellationToken cancellationToken = new CancellationToken())
        {
            await _taskService.UpdateTaskAsync(new DAL.Entities.Task(){});
            return Ok();
        }
    }
}