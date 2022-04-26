using AutoMapper;

namespace task_tracker.ApiEndpoints.Task
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Entities.Task, Response.List>();

            CreateMap<Request.Create, DAL.Entities.Task>();

            CreateMap<DAL.Entities.Task, Response.Create>();
            CreateMap<DAL.Entities.Task, Response.List>();
            CreateMap<Request.Update,DAL.Entities.Task>();
            CreateMap<DAL.Entities.Task, Response.Update>();
            CreateMap<DAL.Entities.Task, Response.Detail>();


        }
    }
}