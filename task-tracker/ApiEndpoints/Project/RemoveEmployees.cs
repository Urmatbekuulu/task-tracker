
using System.Linq;
using System.Threading;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Project
{
    public class RemoveEmployees:EndpointBaseAsync.WithRequest<Request.ChangeEmployees>.WithoutResult
    {
        private readonly ApplicationDbContext _dbContext;

        public RemoveEmployees(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("api/project/removeemployees")]
        [SwaggerOperation(
            Summary = "Removes employess",
            Description = "Removes selected employees from special project",
            OperationId = "Projects.RemoveEmployees",
            Tags = new []{"Projects"})]
        public override async System.Threading.Tasks.Task HandleAsync(Request.ChangeEmployees request, CancellationToken cancellationToken = new CancellationToken())
        {
            var project = _dbContext.Projects
                .Include(p => p.Employees)
                .Single(x=>x.Id==request.ProjectId);
            
            if (project is null) return;
            
            var employees = _dbContext.Employees.Where(e => request.EmployeeIds.Contains(e.Id));

            if(employees is null) return;

            foreach (var employee in employees)
            {
                project.Employees.Remove(employee);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}