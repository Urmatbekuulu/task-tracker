using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;

namespace task_tracker.ApiEndpoints.Project
{
    public class ViewDetail:EndpointBaseAsync.WithRequest<int>.WithResult<ActionResult<Response.Detail>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ViewDetail(IProjectRepository projectRepository,ITaskRepository taskRepository,IMapper mapper,ApplicationDbContext dbContext)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }
        [HttpGet("api/project/view/{id:int:min(1)}")]
        [SwaggerOperation(
            Summary = "view project detail",
            Description = "shows project all detals with tasks",
            OperationId = "Projects.Delete",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<Response.Detail>> HandleAsync(int id, CancellationToken cancellationToken = new CancellationToken())
        {
            var project = _dbContext.Projects.Include(p => p.Employees).Single(x=>x.Id==id);
            if (project is null) return BadRequest("not found");
            
            var response = _mapper.Map<Response.Detail>(project);
            

            var supervisor =await _dbContext.Employees.FindAsync(project.SupervisorId);
            if(supervisor is not  null)
                response.Supervisor = _mapper.Map<Employee.Response.List>(supervisor);

            response.Employees = _mapper.Map<List<Employee.Response.List>>(project.Employees);
            
            var tasks = (await _taskRepository.GetAllAsync()).Where(x => x.ProjectId == id);

            response.Tasks = _mapper.Map<ICollection<Task.Response.List>>(tasks);
            
            
            return response;
        }
    }
}