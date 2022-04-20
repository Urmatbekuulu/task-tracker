using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using task_tracker.Enums;
using task_tracker.Services;

namespace task_tracker.Features.Project.Commands
{
    
    public class CreateProjectCommand:IRequest<Entities.Project>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int Priority { get; set; }
        
        public class CreateProjectCommandHandler:IRequestHandler<CreateProjectCommand,Entities.Project>
        {
            private readonly IProjectService _projectService;
            
            public CreateProjectCommandHandler(IProjectService projectService)
            {
                _projectService = projectService;
            }
            
            public async Task<Entities.Project> Handle(CreateProjectCommand cmd, CancellationToken cancellationToken)
            {
                var project = new Entities.Project()
                {
                    Name = cmd.Name,
                    StartDate = cmd.StartDate,
                    CompletionDate = cmd.CompletionDate,
                    ProjectStatus = cmd.ProjectStatus,
                    Priority = cmd.Priority

                };

                return await _projectService.CreateProject(project);
            }
        }
        
    }
}