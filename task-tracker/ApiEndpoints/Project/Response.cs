using System;
using System.Collections.Generic;

namespace task_tracker.ApiEndpoints.Project
{
    public class Response
    {
        public class Create
        {
           
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
            public ICollection<DAL.Entities.Task> Tasks { get; set; }
        }

        public class Update
        {
            
        }
    

        
        
    }
}