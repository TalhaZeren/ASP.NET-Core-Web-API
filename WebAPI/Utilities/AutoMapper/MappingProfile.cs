using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UserDtoForUpdate,User>();
            CreateMap<User,UserDto>();
            CreateMap<UserDtoForInsertion,User>();
        }
    }
}
