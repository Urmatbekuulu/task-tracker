﻿using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.BLL.Interfaces;
using Entities = task_tracker.DAL.Entities;

namespace task_tracker.ApiEndpoints.Project
{
    public class CreateProject : EndpointBaseAsync
        .WithRequest<Request.Create>
        .WithResult< ActionResult<Response.Create> >
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public CreateProject(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpPost("api/project/create")]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "creates a new project",
            OperationId = "Projects.Create",
            Tags = new[] { "Projects" })
        ]
        public override async  Task<ActionResult<Response.Create>> HandleAsync(Request.Create request, CancellationToken cancellationToken = new CancellationToken())
        {
            var project = _mapper.Map<Entities.Project>(request);
            await _projectService.CreateProjectAsync(project);

            return _mapper.Map<Response.Create>(project);
        }
    
    }
}