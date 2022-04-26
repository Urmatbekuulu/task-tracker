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

namespace task_tracker.ApiEndpoints.Project
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ViewDetail(IProjectRepository projectRepository,ITaskRepository taskRepository,IMapper mapper)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        [HttpGet("api/project/view/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "view project detail",
            Description = "shows project all detals with tasks",
            OperationId = "Projects.Delete",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var project =await _projectRepository.GetByIdAsync(id);
            if (project is null) return BadRequest("not found");
            
            var response = _mapper.Map<Response.Detail>(project);

            var tasks = (await _taskRepository.GetAllAsync()).Where(x => x.ProjectId == id);

            response.Tasks = _mapper.Map<ICollection<Task.Response.List>>(tasks);
            
            return response;
        }
    }
}