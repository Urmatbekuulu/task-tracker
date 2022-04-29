using System.Linq;
using System.Threading;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Project
{
    public class AddEmployee:EndpointBaseAsync.WithRequest<Request.ChangeEmployees>.WithoutResult
    {
        private readonly ApplicationDbContext _dbContext;

        public AddEmployee(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("api/project/addemployees")]
        [SwaggerOperation(
            Summary = "Add Employees to project",
            Description = "Adds employees with ids to special project",
            OperationId = "Project.AddEmployees",
            Tags = new []{"Projects"})]
        public override async System.Threading.Tasks.Task HandleAsync(Request.ChangeEmployees request, CancellationToken cancellationToken = new CancellationToken())
        {
            var project = await _dbContext.Projects.FindAsync(request.ProjectId);
            if (project is null) return;
            var employees = _dbContext.Employees.Where(e => request.EmployeeIds.Contains(e.Id));

            if(employees is null) return;
            
            project.Employees.AddRange(employees);

            await _dbContext.SaveChangesAsync();
        }
    }
}