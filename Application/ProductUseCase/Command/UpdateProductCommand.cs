using Domain.Dtos.Product;
using MediatR;

namespace Application.ProductUseCase.Handler.CommandHandler;

public record UpdateProductCommand(UpdateProductDto UpdateProductDto) : INotification;