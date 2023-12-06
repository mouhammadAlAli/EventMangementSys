using AutoMapper;
using Domain.Authontication;
using Domain.Dtos.Users;
using Domain.Users;

namespace Application.AutoMapperProfiles;

internal class UserMapProfile:Profile
{
    public UserMapProfile()
    {
        CreateMap<CreateUserDto, User>().ForMember(x=>x.Password,src=>src.MapFrom(x=> PasswordHasher.HashPassword(x.Password)));
        CreateMap<UpdateUserDto, User>().ForMember(x => x.Password, src => src.MapFrom(x => PasswordHasher.HashPassword(x.Password)));
        CreateMap<User, UserDto>();
    }
}
