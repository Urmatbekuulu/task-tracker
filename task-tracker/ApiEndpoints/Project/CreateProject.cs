using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;
using task_tracker.BLL.DTOs;
using task_tracker.BLL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject : EndpointBaseAsync.WithRequest<Request.CreateProject>.WithResult<
        ActionResult<Response.CreateProjectResponse>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public CreateProject(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpPost("api/project/create")]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "creates a new project",
            OperationId = "Projects.Create",
            Tags = new[] { "Projects" })
        ]
        public override async  Task<ActionResult<Response.CreateProjectResponse>> HandleAsync(Request.CreateProject request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (ModelState.IsValid)
            {
                var project = _mapper.Map<ProjectDTO>(request);
                
                var result = await _projectService.CreateProjectAsync(new ProjectDTO()
                {
                    
                });
                return Ok();
            }

            return BadRequest("Something was wrong");
        }
    
    }
}