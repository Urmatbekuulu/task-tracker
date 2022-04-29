using AutoMapper;

namespace task_tracker.ApiEndpoints.Employee
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Entities.Employee, Response.List>();
            CreateMap<Request.Update, DAL.Entities.Employee>();
            CreateMap<Request.Create, DAL.Entities.Employee>();
            CreateMap<DAL.Entities.Employee, Response.Create>();
            CreateMap<DAL.Entities.Employee, Response.Detail>();
        }
    }
}