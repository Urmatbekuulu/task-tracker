
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
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
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
           
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task != null)
                return Ok();
            return BadRequest("Something was wrong");
        }
    }
}