using Domain.Dtos.Event;
using MediatR;

namespace Application.EventUseCases.Commands;

public record CreateEventCommand(CreateEventDto CreateEventDto, int UserId):INotification;
