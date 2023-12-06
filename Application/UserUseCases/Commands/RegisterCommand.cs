using Domain.Dtos.Users;
using MediatR;

namespace Application.UserUseCases.Commands;

public record RegisterCommand(CreateUserDto CreateUserDto) : INotification;
