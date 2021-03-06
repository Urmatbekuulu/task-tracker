using System.ComponentModel.DataAnnotations.Schema;
using task_tracker.Enums;

namespace task_tracker.DAL.Entities
{
    public class Task:BaseEntity
    {
        
        public string Name { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
       public ApplicationUser Author { get; set; }
       public string AuthorId { get; set; }
       public string PerformerId { get; set; }
        public ApplicationUser Performer { get; set; }
        public Project Project { get; set;}
        
    }
}