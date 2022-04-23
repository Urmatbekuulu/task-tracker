﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task_tracker.ApiEndpoints.Project.Requests;


namespace task_tracker.ApiEndpoints.Project
{
    public class ViewAll:EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IEnumerable<Response.ViewAll>>>
    {
        private readonly IProjectService _projectService;

        public ViewAll(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet("api/project/view")]
        [SwaggerOperation(
            Summary = "View all",
            Description = "View all projects",
            OperationId = "Projects.View",
            Tags = new[] { "Projects" })
        ]
        public override async Task<ActionResult<IEnumerable<Response.ViewAll>>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var list =  _projectService.GetProjectList();
            return Ok(list.Result.Select(x => new Response.ViewAll()
            {
                Name = x.Name,
                Priority = x.Priority,
                Id = x.Id,
                ProjectStatus = x.ProjectStatus.ToString()
            }));
        }
    }
}