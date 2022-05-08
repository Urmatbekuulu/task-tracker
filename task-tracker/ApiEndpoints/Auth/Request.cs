namespace task_tracker.ApiEndpoints.Auth
{
    public class Request
    {
        public class Authenticate
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}