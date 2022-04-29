using System;
using System.ComponentModel.DataAnnotations;
using task_tracker.DAL.Enums;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Project
{
    public class Request
    {
        public class Create
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string CustomerName { get; set; }
            [Required]
            public string PerformingCompany { get; set; }
            [Required]
            public int SupervisorId { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            [Required]
            public DateTime CompletionDate { get; set; }
            [Required]
            public ProjectStatus ProjectStatus { get; set; }
            [Required]
            public int Priority { get; set; }
        }
        public class Delete
        {
            [Required,Range(1,Int32.MaxValue)]
            public int Id { get; set; }
        }
        

        public class Update:Create
        {
            public int Id { get; set; }
        }
        public class ChangeEmployees
        {
            [Required,Range(1,Int32.MaxValue)]
            public int ProjectId { get; set; }
            [Required]
            public int[] EmployeeIds { get; set; }
        }
    }
}