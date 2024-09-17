using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UserDtoForUpdate,User>().ReverseMap(); // Two sides Mapping.
            CreateMap<User,UserDto>();
            CreateMap<UserDtoForInsertion,User>();
        }
    }
}
