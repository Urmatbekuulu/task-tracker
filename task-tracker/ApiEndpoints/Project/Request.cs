﻿using System;
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
        public class View
        {
            [Required,Range(1,Int32.MaxValue)]
            public int Id { get; set; }
        }

        public class Update
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime CompletionDate { get; set; }
            public string ProjectStatus { get; set; }
            public int Priority { get; set; }
        }
    }
}