using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Project
{
    public class DeleteProject:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<int>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ApplicationDbContext _dbContext;

        public DeleteProject(IProjectRepository projectRepository,ApplicationDbContext dbContext)
        {
            _projectRepository = projectRepository;
            _dbContext = dbContext;
        }
        [HttpDelete("api/project/delete/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "Delete project",
            Description = "Deletes project by id",
            OperationId = "Projects.Delete",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<int>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if(project is null || project.Id<1) return BadRequest("Project not found");
            
            await _projectRepository.DeleteByIdAsync(id);
            await _dbContext.SaveChangesAsync();
          
            return Ok("deleted successfully");
            
        }
    }
}