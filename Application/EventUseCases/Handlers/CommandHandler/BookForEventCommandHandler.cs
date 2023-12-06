using Application.EventUseCases.Commands;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.EventUseCases.Handlers.CommandHandler;

internal class BookForEventCommandHandler : INotificationHandler<BookForEventCommand>
{
    private readonly IEventService _eventService;
    private readonly IUnitOfWork _unitOfWork;

    public BookForEventCommandHandler(IEventService eventService, IUnitOfWork unitOfWork)
    {
        _eventService = eventService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(BookForEventCommand notification, CancellationToken cancellationToken)
    {
        await _eventService.Book(notification.EventId);
        await _unitOfWork.SaveChanges();
    }
}
