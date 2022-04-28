using System.Collections.Generic;

namespace task_tracker.DAL.Entities
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string  Email { get; set; }
        public List<Project> Projects { get; set; }
    }
}