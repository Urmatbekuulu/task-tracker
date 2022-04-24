using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public ViewDetail(IProjectService projectService,ITaskService taskService,IMapper mapper)
        {
            _projectService = projectService;
            _taskService = taskService;
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
            var project =await _projectService.GetProjectByIdAsync(id);
            var response = _mapper.Map<Project.Response.Detail>(project);

            var taskResult = (await _taskService.FindTasksAsync(t => t.Id == response.Id))
                .Select(x=>_mapper.Map<Task.Response.List>(x))
                .ToList();

            return Ok(taskResult);
        }
    }
}