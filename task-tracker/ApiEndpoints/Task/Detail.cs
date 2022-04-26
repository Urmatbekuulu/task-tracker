
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class ViewDetail : EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ViewDetail(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }



        [HttpGet("api/task/view/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "detailed task",
            Description = "all information about task",
            OperationId = "Task.ViewDetail",
            Tags = new[] {"Tasks"})
        ]
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id,
            CancellationToken cancellationToken = new CancellationToken())
        {

            var task = await _taskRepository.GetByIdAsync(id);

            if (task is null) return BadRequest("Task not found");

            return _mapper.Map<Response.Detail>(task);
        }
    }
}