using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Create:EndpointBaseAsync.WithRequest<Request.Create>.WithResult<ActionResult<Response.Create>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        
        public Create(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

       
        [HttpPost("api/empmloyee/create")]
        [SwaggerOperation(
            Summary = "Creates Employee",
            Description = "creates a new employee",
            OperationId = "Employee.Create",
            Tags = new[] { "Employee" })
        ]
        public override async Task<ActionResult<Response.Create>> HandleAsync(Request.Create request, CancellationToken cancellationToken = new CancellationToken())
        {
            var employee = _mapper.Map<DAL.Entities.ApplicationUser>(request);
            var result = await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();

            employee = await _dbContext.Employees.FindAsync(result.Entity.Id);
            
            return _mapper.Map<Response.Create>(employee);
        }
    }
}