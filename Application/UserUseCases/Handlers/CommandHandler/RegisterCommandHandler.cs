using Application.UserUseCases.Commands;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.UserUseCases.Handlers.CommandHandler;

internal class RegisterCommandHandler : INotificationHandler<RegisterCommand>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterCommand notification, CancellationToken cancellationToken)
    {
        await _userService.Create(notification.CreateUserDto);
        await _unitOfWork.SaveChanges();
    }
}
