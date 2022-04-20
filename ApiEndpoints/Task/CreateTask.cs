using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.Services;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class CreateTask:EndpointBaseAsync.WithRequest<Task.Request.CreateTask>.WithResult<ActionResult<Task.Response.CreatedTask>>
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
        public override async Task<ActionResult<Task.Response.CreatedTask>> HandleAsync(Task.Request.CreateTask request, CancellationToken cancellationToken = new CancellationToken())
        {

            var result = await _taskService.CreateTask(new Entities.Task()
            {
                Name = request.Name,
                Priority = request.Priority,
                ProjectId = request.ProjectId,
                TaskStatus = request.TaskStatus,
                Description = request.Description
                
            });
            if (result != null)
                return Ok(new Task.Response.CreatedTask()
                {
                    Name = result.Name,
                    Description = result.Description,
                    Priority = result.Priority,
                    TaskStatus = request.TaskStatus.ToString(),
                    Id = result.Id,
                    ProjectId = result.ProjectId
                });
            return BadRequest("Something was wrong");
        }
    }
}