using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Task
{
    public class ViewAll:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IEnumerable<Response.List>>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ViewAll(ITaskRepository taskRepository,IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        [HttpGet("api/task/view")]
        [SwaggerOperation(
            Summary = "Get all Tasks",
            Description = "Get all tasks",
            OperationId = "Task.ViewAll",
            Tags = new[] { "Tasks" })
        ]
        public override async Task<ActionResult<IEnumerable<Response.List>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = (await _taskRepository.GetAllAsync());
            return Ok(_mapper.Map<IEnumerable<Response.List>>(result));



        }
    }
}