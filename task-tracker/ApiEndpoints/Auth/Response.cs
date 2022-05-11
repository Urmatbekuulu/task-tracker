using System;

namespace task_tracker.ApiEndpoints.Auth
{
    public class Response
    {
        public class Login
        {
            public string Username { get; set; }

            public string UserId { get; set; }
            
            public string JwtToken { get; set; }

            public DateTime JwtExpires { get; set; }

            public string RefreshToken { get; set; }

            public DateTime RefreshExpires { get; set; }
        }
    }
}