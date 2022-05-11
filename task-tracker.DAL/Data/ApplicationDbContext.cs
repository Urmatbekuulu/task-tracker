using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Identity;
using Task = task_tracker.DAL.Entities.Task;


namespace task_tracker.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ApplicationUser> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.CreatedTasks)
                .WithOne(t => t.Author)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.ToDoTasks)
                .WithOne(t => t.Performer)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole(RoleConstants.ADMINSTRATOR){NormalizedName = RoleConstants.ADMINSTRATOR},
                    new IdentityRole(RoleConstants.MANAGER){NormalizedName = RoleConstants.MANAGER},
                    new IdentityRole(RoleConstants.EMPLOYEE){NormalizedName = RoleConstants.EMPLOYEE}


                );
        }
    }
}