using AutoMapper;

namespace task_tracker.ApiEndpoints.Task
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Entities.Task, Response.List>();

        }
    }
}