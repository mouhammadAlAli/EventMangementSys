using Domain.Dtos.Product;
using MediatR;

namespace Application.ProductUseCase.Queries;
public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
