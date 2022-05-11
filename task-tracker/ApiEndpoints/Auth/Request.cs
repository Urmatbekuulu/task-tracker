using System.ComponentModel.DataAnnotations;

namespace task_tracker.ApiEndpoints.Auth
{
    public class Request
    {
        public class Login
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
           
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}