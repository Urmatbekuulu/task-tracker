using System;
using System.Collections.Generic;
using task_tracker.DAL.Enums;

namespace task_tracker.DAL.Entities
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string PerformingCompany { get; set; }
        public string SupervisorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int Priority { get; set; }
        public List<Employee> Employees { get; set; } = new();
        public List<Task> Tasks { get; set; } = new();

    }
}