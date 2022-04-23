﻿using System.ComponentModel.DataAnnotations;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Task
{
    public class Response
    {
        public class CreatedTask
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string TaskStatus { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public int Priority { get; set; }
            [Required]
            public int ProjectId { get; set; }
        }
        public class ViewAllTask
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string TaskStatus { get; set; }
            [Required]
            public int ProjectId { get; set; }
        }
        public class ViewDetail:CreatedTask
        {
            
        }
    }
}