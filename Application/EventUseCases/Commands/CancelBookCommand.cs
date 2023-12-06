using MediatR;

namespace Application.EventUseCases.Commands;

public record CancelBookCommand(int EventId):INotification;
