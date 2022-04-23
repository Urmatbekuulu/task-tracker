using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class DeleteTask:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<int>>
    {
        private readonly ITaskService _taskService;

        public DeleteTask(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpDelete("api/task/delete/{id:int}")]
        [SwaggerOperation(
            Summary = "Delete Task",
            Description = "Deletes a Task with id",
            OperationId = "Task.Delete",
            Tags = new[] { "Tasks" })
        ]
        public override Task<ActionResult<int>> HandleAsync(int request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}