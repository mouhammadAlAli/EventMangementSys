using Domain.Dtos.Event;
using MediatR;

namespace Application.EventUseCases.Quiries;

public record GetMyEventsQuery():IRequest<List<EventDto>>;
