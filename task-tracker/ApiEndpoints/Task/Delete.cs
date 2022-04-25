using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;


namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class DeleteTask:EndpointBaseAsync.WithRequest<Request.Delete>.WithResult<ActionResult>
    {
        private readonly ITaskService _taskService;
        private readonly ApplicationDbContext _dbContext;

        public DeleteTask(ITaskService taskService,ApplicationDbContext dbContext)
        {
            _taskService = taskService;
            _dbContext = dbContext;
        }
        [HttpDelete("api/task/delete/{id:int}")]
        [SwaggerOperation(
            Summary = "Delete Task",
            Description = "Deletes a Task with id",
            OperationId = "Task.Delete",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult> HandleAsync(Request.Delete request, CancellationToken cancellationToken = new CancellationToken())
        {
            await _taskService.DeleteTaskAsync(request.Id);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}