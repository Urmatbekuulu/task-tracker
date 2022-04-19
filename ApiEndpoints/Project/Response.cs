using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class Response
    {
        public class CreateProjectResponse
        {
            public string Name { get; set; }
        }
    }
}