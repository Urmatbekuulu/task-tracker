using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class UpdateTask:EndpointBaseAsync.WithRequest<Request.Update>.WithResult<ActionResult<Response.Update>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public UpdateTask(ITaskRepository taskRepository,IMapper mapper,ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _dbContext = dbContext;
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
            var task = _mapper.Map<DAL.Entities.Task >(request);
            await _taskRepository.UpdateAsync(task);
            await _dbContext.SaveChangesAsync();

            var updated =await _taskRepository.GetByIdAsync(task.Id);
            
            return _mapper.Map<Response.Update>(updated);
        }
    }
}