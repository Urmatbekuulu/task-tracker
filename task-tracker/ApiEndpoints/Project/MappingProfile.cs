using AutoMapper;
using Entities = task_tracker.DAL.Entities;
namespace task_tracker.ApiEndpoints.Project
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Request.Create, Entities.Project>();
            CreateMap<Entities.Project, Response.Create>();

            CreateMap<Entities.Project, Response.Detail>();
            CreateMap<Entities.Project, Response.List>();

            CreateMap<Request.Update, Entities.Project>();
        }
    }
}