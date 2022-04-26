using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using task_tracker.DAL.Interfaces;


namespace task_tracker.ApiEndpoints.Project
{
    public class List:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<List<Response.List>>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public List(IProjectRepository projectRepository,IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        [HttpGet("api/project/view")]
        [SwaggerOperation(
            Summary = "View all",
            Description = "View all projects",
            OperationId = "Projects.View",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<List<Response.List>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var list = (await _projectRepository.GetAllAsync());
            var response = _mapper.Map<List<Response.List>>(list);

            return response;
        }
    }
}