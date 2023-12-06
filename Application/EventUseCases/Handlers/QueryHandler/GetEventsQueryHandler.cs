using Application.EventUseCases.Quiries;
using Domain;
using Domain.Authontication;
using Domain.Dtos.Event;
using Domain.Events;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;
using System.Linq.Expressions;


namespace Application.EventUseCases.Handlers.QueryHandler;

internal class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, PageResult<EventDto>>
{
    private readonly IEventService _eventService;
    private readonly IAuthonticateUserSerivce _authonticateUserSerivce;
    public GetEventsQueryHandler(IEventService eventService, IAuthonticateUserSerivce authonticateUserSerivce)
    {
        _eventService = eventService;
        _authonticateUserSerivce = authonticateUserSerivce;
    }

    public Task<PageResult<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<Event, bool>> predicate = null;
        if (request.eventPagedRequestDto.IsAvaliable.HasValue)
        {
            if (request.eventPagedRequestDto.IsAvaliable.Value)
                predicate = c => c.AvailableTickets > 0;
            else
                predicate = c => c.AvailableTickets == 0;
        }
        
        if (_authonticateUserSerivce.GetUserRole() == AppConsts.EventMangerRole)
        {
            var userId = _authonticateUserSerivce.GetUserId();
            if (predicate == null)
            {
                predicate = c => c.UserId == userId;
            }
            else
            {
                Expression<Func<Event, bool>> userExpression = c => c.UserId == userId;
                var invoked = Expression.Invoke(userExpression, predicate.Parameters);
                predicate = Expression.Lambda<Func<Event, bool>>(Expression.AndAlso(predicate.Body, invoked), predicate.Parameters);
            }
        }
        return _eventService.GetPage(request.eventPagedRequestDto, predicate, c => c.Translations);

    }
}
