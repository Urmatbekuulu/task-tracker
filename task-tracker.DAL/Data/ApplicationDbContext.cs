using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using task_tracker.DAL.Entities;


namespace task_tracker.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}