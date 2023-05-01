using Domain.Dtos.Product;
using Domain.Repositries.Common;
using MediatR;

namespace Application.ProductUseCase.Queries;

public record GetProductBasedOnCurrentTimeQuery(PageRequest PageRequest):IRequest<PageResult<ProductDto>>;
