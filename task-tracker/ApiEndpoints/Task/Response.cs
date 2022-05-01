using System.ComponentModel.DataAnnotations;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Task
{
    public class Response
    {
        public class Create
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public TaskStatus TaskStatus { get; set; }
            public string Description { get; set; }
            public int Priority { get; set; }
            public int ProjectId { get; set; }
            public int AuthorId { get; set; }
            public int PerformerId { get; set; }
            
        }
        public class List
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string TaskStatus { get; set; }
            [Required]
            public int ProjectId { get; set; }
        }
        public class Detail:Create
        {
            
        }
        public class Update
        {
            
        }
    }
}