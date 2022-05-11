using AutoMapper;

namespace task_tracker.ApiEndpoints.Employee
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Entities.ApplicationUser, Response.List>();
            CreateMap<Request.Update, DAL.Entities.ApplicationUser>();
            CreateMap<Request.Create, DAL.Entities.ApplicationUser>();
            CreateMap<DAL.Entities.ApplicationUser, Response.Create>();
            CreateMap<DAL.Entities.ApplicationUser, Response.Detail>();
        }
    }
}