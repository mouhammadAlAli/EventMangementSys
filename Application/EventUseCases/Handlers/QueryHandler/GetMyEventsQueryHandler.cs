using Application.EventUseCases.Quiries;
using Domain.Dtos.Event;
using Domain.Services;
using MediatR;

namespace Application.EventUseCases.Handlers.QueryHandler;

internal class GetMyEventsQueryHandler : IRequestHandler<GetMyEventsQuery, List<EventDto>>
{
    private readonly IEventService _eventService;

    public GetMyEventsQueryHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public Task<List<EventDto>> Handle(GetMyEventsQuery request, CancellationToken cancellationToken)
    {
        return _eventService.GetMyEvent();
    }
}
