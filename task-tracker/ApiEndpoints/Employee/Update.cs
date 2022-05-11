using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Update:EndpointBaseAsync
        .WithRequest<Request.Update>
        .WithResult<ActionResult<Response.Update>>

    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Update(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPut("api/employee/update")]
        [SwaggerOperation(
            Summary = "Update Employee",
            Description = "Updates employee",
            OperationId = "Employee.Update",
            Tags = new []{"Employee"}
            )]
        public override async Task<ActionResult<Response.Update>> HandleAsync(Request.Update request, CancellationToken cancellationToken = new CancellationToken())
        {
            var employee = _mapper.Map<DAL.Entities.ApplicationUser>(request);
            if (!(await IsValid(employee))) return BadRequest("Something went wrong");
            var realemp =await _dbContext.Employees.FindAsync(employee.Id);

            if (realemp is null) return BadRequest("Unable to update");

            _dbContext.Employees.Update(employee);
            
            await _dbContext.SaveChangesAsync();
            
            return Ok("Success");
        }

        /// <summary>
        /// validation 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private async Task<bool> IsValid(DAL.Entities.ApplicationUser? employee)
        {
            if (employee == null ) return false;
            return true;
        }
    }
}