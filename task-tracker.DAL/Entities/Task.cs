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
        
    }
}