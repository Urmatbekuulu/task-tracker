
using System.ComponentModel.DataAnnotations;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Task
{
    public class Request
    {
        public class CreateTask
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public TaskStatus TaskStatus { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public int Priority { get; set; }
            [Required]
            public int ProjectId { get; set; }
            
        }
        public class UpdateTask:CreateTask
        {
            public int Id { get; set; }
        }
        

       
    }
    
    
}