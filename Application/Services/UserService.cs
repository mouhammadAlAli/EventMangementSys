using Application.Exceptions;
using AutoMapper;
using Domain.Authontication;
using Domain.Dtos.Users;
using Domain.Repositries;
using Domain.Services;
using Domain.Users;
using Microsoft.Extensions.Options;

namespace Application.Services;

internal class UserService : GenaricSerivce<User, UserDto, CreateUserDto, UpdateUserDto>, IUserService
{
    private readonly ITokenGenerator _tokenGenerator;
    public UserService(IRepository<User> repository, IMapper mapper,ITokenGenerator tokenGenerator) : base(repository, mapper)
    {
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _repository.FirstOrDefualt(c=>c.Email.ToLower()==username.ToLower(),c=>c.Role)?? throw new ConflictException("user not exists");
        if (!PasswordHasher.VerifyPassword(password, user.Password))
        {
            throw new ConflictException("user not exists");
        }
        return  _tokenGenerator.GenerateToken(user);
    }
}
