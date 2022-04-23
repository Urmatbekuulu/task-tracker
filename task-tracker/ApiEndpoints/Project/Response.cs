using System;
using System.Collections.Generic;
using task_tracker.BLL.DTOs;

namespace task_tracker.ApiEndpoints.Project.Requests
{
    public class Response
    {
        public class CreateProjectResponse
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
            public ICollection<TaskDTO> Tasks { get; set; }
        }
    

        
        
    }
}