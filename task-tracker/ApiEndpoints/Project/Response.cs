using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using task_tracker.DAL.Enums;

namespace task_tracker.ApiEndpoints.Project
{
    public class Response
    {
        public class Create
        {
            public int Id { get; set; }
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
       
        public class List
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }
            public string ProjectStatus { get; set; }
            
        }
        public class Detail
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int Priority { get; set; }
            public string ProjectStatus { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime CompletionDate { get; set; }
            public ICollection<Task.Response.List> Tasks { get; set; }
        }

        public class Update
        {
            
        }
    

        
        
    }
}