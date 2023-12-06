using MediatR;

namespace Application.EventUseCases.Commands;

public record BookForEventCommand(int EventId):INotification;

