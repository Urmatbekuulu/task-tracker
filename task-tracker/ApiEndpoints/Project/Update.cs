using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class Update:EndpointBaseAsync.WithRequest<Request.Update>.WithResult<ActionResult<Response.Update>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public Update(IProjectRepository projectRepository,IMapper mapper,ApplicationDbContext context)
        {
            _projectRepository = projectRepository;
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
            await _projectRepository.UpdateAsync(project);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}