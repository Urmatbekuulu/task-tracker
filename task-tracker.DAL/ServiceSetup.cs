using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task_tracker.DAL.Data;
using task_tracker.DAL.Interfaces;
using task_tracker.DAL.Repositories;

namespace task_tracker.DAL
{
    public static class ServiceSetup
    {
        public static void AddDAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GetDefaultConnection"));
            });
            //add unit of pattern service 
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

        }
    }
    
}