using Microsoft.EntityFrameworkCore;
using task_tracker.Entities;

namespace task_tracker.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}