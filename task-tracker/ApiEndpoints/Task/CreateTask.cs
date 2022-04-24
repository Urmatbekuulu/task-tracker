using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class CreateTask:EndpointBaseAsync.WithRequest<Request.Create>.WithResult<ActionResult<Response.Create>>
    {
        private readonly ITaskService _taskService;

        public CreateTask(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpPost("api/task/create")]
        [SwaggerOperation(
            Summary = "Create Task",
            Description = "Creates a task to a project",
            OperationId = "Task.Create",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<Response.Create>> HandleAsync(Task.Request.Create request, CancellationToken cancellationToken = new CancellationToken())
        {

            return Ok();
        }
    }
}