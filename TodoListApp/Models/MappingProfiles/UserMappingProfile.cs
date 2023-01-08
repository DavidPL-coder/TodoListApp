using AutoMapper;
using TodoListApp.DAL.Entities;

namespace TodoListApp.Models.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<RegisterUserDTO, User>();
        }
    }
}
