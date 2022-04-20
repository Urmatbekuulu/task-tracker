using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using task_tracker.Entities;
using task_tracker.Enums;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class Response
    {
        public class CreateProjectResponse:Entities.Project
        {
           
        }
       
        public class ViewAll
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }
            public string ProjectStatus { get; set; }
            
        }
        public class ViewDetailly
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int Priority { get; set; }
            public string ProjectStatus { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime CompletionDate { get; set; }
            public ICollection<Entities.Task> Tasks { get; set; }
        }
    

        
        
    }
}