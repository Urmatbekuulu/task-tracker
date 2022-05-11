using AutoMapper;
using task_tracker.DAL.Entities;

namespace task_tracker.ApiEndpoints.Registration
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Request.Register, ApplicationUser>();
        }
        
    }
}