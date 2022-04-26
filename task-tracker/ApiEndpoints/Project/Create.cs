using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;
using Entities = task_tracker.DAL.Entities;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject : EndpointBaseAsync
        .WithRequest<Request.Create>
        .WithResult< ActionResult<Response.Create> >
    {
        private readonly IProjectRepository _projectRepository;
        
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public CreateProject(IProjectRepository projectRepository,IMapper mapper,ApplicationDbContext dbContext)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        [HttpPost("api/project/create")]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "creates a new project",
            OperationId = "Projects.Create",
            Tags = new[] { "Projects" })
        ]
        public override async  Task<ActionResult<Response.Create>> HandleAsync(Request.Create request, CancellationToken cancellationToken = new CancellationToken())
        { 
            var project = _mapper.Map<Entities.Project>(request);
            var result = await _projectRepository.CreateAsync(project); 
            await _dbContext.SaveChangesAsync();
            
            return _mapper.Map<Response.Create>(result);
        }
    
    }
}