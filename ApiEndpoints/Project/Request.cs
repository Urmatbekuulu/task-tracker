﻿using System;
using System.ComponentModel.DataAnnotations;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Project
{
    public class Request
    {
        public class CreateProject
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            [Required]
            public DateTime CompletionDate { get; set; }
            [Required]
            public ProjectStatus ProjectStatus { get; set; }
            [Required]
            public int Priority { get; set; }
        }
        public class DeleteProject
        {
            [Required,Range(1,Int32.MaxValue)]
            public int Id { get; set; }
        }
        public class ViewDetail
        {
            [Required,Range(1,Int32.MaxValue)]
            public int Id { get; set; }
        }
    }
}