using System.Collections.Generic;
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
    public class List:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IEnumerable<Response.List>>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public List(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpGet("api/project/view")]
        [SwaggerOperation(
            Summary = "View all",
            Description = "View all projects",
            OperationId = "Projects.View",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<IEnumerable<Response.List>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var list = (await _projectService.GetProjectsAsync()).Select(x => _mapper.Map<Response.List>(x));
            
            return Ok(list);
        }
    }
}