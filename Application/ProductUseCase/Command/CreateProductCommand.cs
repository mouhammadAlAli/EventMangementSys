using Domain.Dtos.Product.CreateProductDtos;
using MediatR;

namespace Application.ProductUseCase.Command;

public record CreateProductCommand(CreateProductDto CreateProductDto) : INotification;
