
using System;
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
            [Required,Range(1,Int32.MaxValue)]
            public int ProjectId { get; set; }
            [Required]
            public string AuthorId { get; set; }
            [Required]
            public string PerformerId { get; set; }
            
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
            public int Id { get; set; }
        }
        

       
    }
    
    
}