using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Delete:EndpointBaseAsync.WithRequest<Request.Delete>.WithResult<ActionResult<Response.Delete>>
    { 
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Delete(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpDelete("api/empmloyee/delete/")]
        [SwaggerOperation(
            Summary = "Delete Employee",
            Description = "Deletes Employee by id",
            OperationId = "Employee.Delete",
            Tags = new[] { "Employee" })
        ]
        public override async Task<ActionResult<Response.Delete>> HandleAsync(Request.Delete request, CancellationToken cancellationToken = new CancellationToken())
        {
            var employee = await _dbContext.Employees.FindAsync(request.Id);

            if (employee is null) return BadRequest("Employee with given Id not found");

            var result = _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync();
            return Ok(  "Successfully delted");
        }
    }
}