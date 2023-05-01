using Domain.Dtos.Product;
using Domain.Repositries.Common;
using MediatR;

namespace Application.ProductUseCase.Queries;

public record GetProductQuery(PageRequest PageRequest) : IRequest<PageResult<ProductDto>>;

