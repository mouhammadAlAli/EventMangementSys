using Application.EventUseCases.Commands;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.EventUseCases.Handlers.CommandHandler;

internal class CancelBookCommandHandler : INotificationHandler<CancelBookCommand>
{
    private readonly IEventService _eventService;
    private readonly IUnitOfWork _unitOfWork;

    public CancelBookCommandHandler(IEventService eventService, IUnitOfWork unitOfWork)
    {
        _eventService = eventService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CancelBookCommand notification, CancellationToken cancellationToken)
    {
        await _eventService.CancelBook(notification.EventId);
        await _unitOfWork.SaveChanges();
    }
}
