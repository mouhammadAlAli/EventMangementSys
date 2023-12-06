using Domain.Dtos.Users;
using Domain.Users;

namespace Domain.Services;

public interface IUserService:IGenaricSerivce<User, UserDto,CreateUserDto,UpdateUserDto>
{
    Task<string> Login(string username, string password);
}
