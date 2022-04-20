using System;
using System.Collections.Generic;
using task_tracker.Enums;

namespace task_tracker.Entities
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int Priority { get; set; }
        
    }
}