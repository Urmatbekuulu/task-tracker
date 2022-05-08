namespace task_tracker.ApiEndpoints.Employee
{
    public class Response
    {
        public class Create
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string? MiddleName { get; set; }
            public string  Email { get; set; }
        }

        public class Update
        {
            
        }

        public class Delete
        {
            
        }

        public class List
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string? MiddleName { get; set; }
            public string  Email { get; set; }
        }

        public class Detail:Create
        {
            
        }

    }
}