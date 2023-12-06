using Domain.Dtos.Event;
using MediatR;

namespace Application.EventUseCases.Commands;

public record UpdateEventCommand(UpdateEventDto UpdateEventDto, int UserId):INotification;

