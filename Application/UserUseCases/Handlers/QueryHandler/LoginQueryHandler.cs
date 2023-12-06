using Application.Exceptions;
using Application.UserUseCases.Queries;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserUseCases.Handlers.QueryHandler;

public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
{
    private readonly IUserService _userService;

    public LoginQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return _userService.Login(request.Email, request.Passowrd);
    }
}
