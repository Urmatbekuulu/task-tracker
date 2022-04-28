using System.ComponentModel.DataAnnotations;

namespace task_tracker.ApiEndpoints.Employee
{
    public class Request
    {
        public class Create
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            public string? MiddleName { get; set; }
            [Required]
            public string  Email { get; set; }
        }

        public class Update:Create
        {
            [Required]
            public int Id { get; set; }
            
        }
        public class Delete
        {
            
        }

        public class List
        {
            
        }
        
    }
}