using Domain.Authontication;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Authontication;

internal class AuthonticateUserSerivce: IAuthonticateUserSerivce
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthonticateUserSerivce(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var user = _httpContextAccessor.HttpContext.User;
        if (user.Identity.IsAuthenticated)
        {
            var userId = user.Claims.First(c => c.Type == ITokenGenerator.Id).Value;
            return int.Parse(userId);
        }
        return 0;
        
    }

    public string GetUserRole()
    {
        var user = _httpContextAccessor.HttpContext.User;
        if (user.Identity.IsAuthenticated)
        {
            var userRole = user.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            return userRole;
        }
        return null;
    }
}
