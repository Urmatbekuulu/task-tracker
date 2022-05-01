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
       public Employee Author { get; set; }
       public int AuthorId { get; set; }
       public int PerformerId { get; set; }
        public Employee Performer { get; set; }
        public Project Project { get; set;}
        
    }
}