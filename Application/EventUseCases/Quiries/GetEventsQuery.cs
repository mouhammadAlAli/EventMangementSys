using Domain.Dtos.Event;
using Domain.Repositries.Common;
using MediatR;

namespace Application.EventUseCases.Quiries;

public record GetEventsQuery(EventPagedRequestDto eventPagedRequestDto) :IRequest<PageResult<EventDto>>;
