using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class CreateTask:EndpointBaseAsync.WithRequest<Request.Create>.WithResult<ActionResult<Response.Create>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public CreateTask(ITaskRepository taskRepository,IMapper mapper,ApplicationDbContext dbContext)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _dbContext = dbContext;
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
            var result =  await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            task =await _taskRepository.GetByIdAsync(result.Entity.Id);

            return _mapper.Map<Response.Create>(task);

        }

        private bool IsRequestValid(Request.Create request)
        {
            
            var isProjectExists =  _dbContext.Projects.Find(request.ProjectId);
            return isProjectExists is not null;
        }
        
    }
}