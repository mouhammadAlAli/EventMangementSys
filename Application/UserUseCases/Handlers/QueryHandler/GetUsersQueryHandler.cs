using Application.UserUseCases.Queries;
using Domain.Dtos.Users;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;

namespace Application.UserUseCases.Handlers.QueryHandler;

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PageResult<UserDto>>
{
    private readonly IUserService _userService;

    public GetUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<PageResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetPage(request.PageRequest,null);
    }
}
