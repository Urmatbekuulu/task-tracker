using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Detail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Detail(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("api/employee/view/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "Detailed employee",
            Description = "Gives detailed information about employee",
            OperationId = "Employee.Detail",
            Tags = new []{"Employee"})]
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var employee =await _dbContext.Employees.FindAsync(id);
            if (employee is null) return BadRequest("Information about given Id not found");
            var response = _mapper.Map<Response.Detail>(employee);
            
            return response;

        }
    }
}