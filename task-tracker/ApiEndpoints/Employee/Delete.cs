using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Delete:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Delete>>
    { 
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Delete(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpDelete("api/empmloyee/delete/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "Delete Employee",
            Description = "Deletes Employee by id",
            OperationId = "Employee.Delete",
            Tags = new[] { "Employee" })
        ]
        public override async Task<ActionResult<Response.Delete>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!(await IsValidId(id))) return BadRequest("Error from resx resource can be send");
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee is null) return BadRequest("Employee with given Id not found");

            var result = _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync();
            return Ok(  "Successfully delted");
        }

        private async Task<bool> IsValidId(int id)
        {
            if (id < 1) return false;

            return true;
        }
    }
}