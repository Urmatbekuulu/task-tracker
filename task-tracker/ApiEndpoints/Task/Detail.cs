
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _dbContext;

        public ViewDetail(ITaskRepository taskRepository, IMapper mapper,ApplicationDbContext dbContext)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _dbContext = dbContext;
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

            var task = await _dbContext.Tasks.FindAsync(id);

            if (task is null) return BadRequest("Task not found");

            return _mapper.Map<Response.Detail>(task);
        }
    }
}