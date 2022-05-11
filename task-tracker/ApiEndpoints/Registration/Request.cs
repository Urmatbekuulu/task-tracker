using System.ComponentModel.DataAnnotations;

namespace task_tracker.ApiEndpoints.Registration
{
    public class Request
    {
        public class Register
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Middlename { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            public string Username { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}