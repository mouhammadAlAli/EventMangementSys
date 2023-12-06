using Application.EventUseCases.Commands;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.EventUseCases.Handlers.CommandHandler;

internal class UpdateEventCommandHandler : INotificationHandler<UpdateEventCommand>
{
    private readonly IEventService _eventService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventCommandHandler(IEventService eventService, IUnitOfWork unitOfWork)
    {
        _eventService = eventService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateEventCommand notification, CancellationToken cancellationToken)
    {
        await _eventService.Update(notification.UpdateEventDto);
        await _unitOfWork.SaveChanges();
    }
}
