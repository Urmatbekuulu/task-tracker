
using System.ComponentModel.DataAnnotations;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Task
{
    public class Request
    {
        public class Create
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
        public class Update:Create
        {
            public int Id { get; set; }
        }
        public class Delete
        {
            
        }
        public class List
        {
            
        }
        public class Detail
        {
            
        }
        

       
    }
    
    
}