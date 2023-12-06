using Domain.Dtos.Users;
using Domain.Repositries.Common;
using MediatR;

namespace Application.UserUseCases.Queries;

public record GetUsersQuery(PageRequest PageRequest) : IRequest<PageResult<UserDto>>;

