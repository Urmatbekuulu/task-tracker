using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class CreateTask:EndpointBaseAsync.WithRequest<Request.Create>.WithResult<ActionResult<Response.Create>>
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public CreateTask(ITaskService taskService,IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        
        [HttpPost("api/task/create")]
        [SwaggerOperation(
            Summary = "Create Task",
            Description = "Creates a task to a project",
            OperationId = "Task.Create",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<Response.Create>> HandleAsync(Request.Create request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!IsRequestValid(request)) return BadRequest("error");
            var task = _mapper.Map<DAL.Entities.Task>(request);
            await _taskService.CreateTaskAsync(task);
            
            return Ok();
        }

        private bool IsRequestValid(Request.Create request)
        {
            // there will be any validation operations to check
            return request.ProjectId>0;
        }
        
    }
}