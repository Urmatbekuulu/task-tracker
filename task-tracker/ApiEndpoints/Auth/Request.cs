namespace task_tracker.ApiEndpoints.Auth
{
    public class Request
    {
        public class Login
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}