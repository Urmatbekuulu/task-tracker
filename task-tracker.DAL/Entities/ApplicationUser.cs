using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace task_tracker.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Middlename { get; set; }
        
        public List<Project> Projects { get; set; } = new();
        
        public List<Task> CreatedTasks { get; set; } = new();
        public List<Task> ToDoTasks { get; set; } = new();
    }
}