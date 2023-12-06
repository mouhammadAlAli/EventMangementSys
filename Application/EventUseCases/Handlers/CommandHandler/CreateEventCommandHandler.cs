using Application.EventUseCases.Commands;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.EventUseCases.Handlers.CommandHandler;

internal class CreateEventCommandHandler : INotificationHandler<CreateEventCommand>
{
    private readonly IEventService _eventService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventService eventService, IUnitOfWork unitOfWork)
    {
        _eventService = eventService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateEventCommand notification, CancellationToken cancellationToken)
    {
        await _eventService.Create(notification.CreateEventDto);
        await _unitOfWork.SaveChanges();
    }
}
