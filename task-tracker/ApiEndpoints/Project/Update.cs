using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class Update:EndpointBaseAsync.WithRequest<Request.Update>.WithResult<ActionResult<Response.Update>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public Update(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpPut("api/project/update")]
        [SwaggerOperation(
            Summary = "Updates project",
            Description = "Updates existing project",
            OperationId = "Projects.Updated",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<Response.Update>> HandleAsync(Request.Update request, CancellationToken cancellationToken = new CancellationToken())
        {

            return BadRequest();
        }
    }
}