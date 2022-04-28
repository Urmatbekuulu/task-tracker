using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.DAL.Data;

namespace task_tracker.ApiEndpoints.Employee
{
    public class List:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<List<Response.List>>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public List(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("api/employees/view")]
        [SwaggerOperation(
            Summary = "List of Employees",
            Description = "Gets all List of Employees",
            OperationId ="Employee.List",
            Tags = new []{"Employee","View"})]
        public override async Task<ActionResult<List<Response.List>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           var employees = await _dbContext.Employees.ToListAsync();
           
           return _mapper.Map<List<Response.List>>(employees.ToList());
        }
    }
}