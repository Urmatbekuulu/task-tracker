using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Project
{
    public class Update:EndpointBaseAsync.WithRequest<Request.Update>.WithResult<ActionResult<Response.Update>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public Update(IProjectService projectService,IMapper mapper,ApplicationDbContext context)
        {
            _projectService = projectService;
            _mapper = mapper;
            _context = context;
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
            var project = _mapper.Map<DAL.Entities.Project>(request); 
            await _projectService.UpdateProjectAsync(project);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}