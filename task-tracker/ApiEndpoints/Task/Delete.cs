using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class DeleteTask:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ApplicationDbContext _dbContext;

        public DeleteTask(ITaskRepository taskRepository,ApplicationDbContext dbContext)
        {
            _taskRepository = taskRepository;
            _dbContext = dbContext;
        }
        [HttpDelete("api/task/delete/{id:int}")]
        [SwaggerOperation(
            Summary = "Delete Task",
            Description = "Deletes a Task with id",
            OperationId = "Task.Delete",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            await _taskRepository.DeleteByIdAsync(id);
            await _dbContext.SaveChangesAsync();
            return Ok(); 
        }
    }
}