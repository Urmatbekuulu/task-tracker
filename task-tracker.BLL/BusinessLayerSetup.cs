using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task_tracker.BLL.Interfaces;
using task_tracker.BLL.Services;
using task_tracker.DAL;

namespace task_tracker.BLL
{
    public static class BusinessLayerSetup
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();

        }
        
    }
}