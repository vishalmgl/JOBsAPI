using AutoMapper;
using SimpleJobAPI.DTOs;
using SimpleJobAPI.Models;

namespace SimpleJobAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Job to JobDTO
            CreateMap<Job, JobDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.AssignedUsers.Select(ua => ua.User)));

            

            // Map JobDTO to Job
            CreateMap<JobDTO, Job>()
                .ForMember(dest => dest.AssignedUsers, opt => opt.Ignore()); // Prevent circular mapping

            // Map User to UserDTO
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
