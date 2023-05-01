using Domain.Dtos.Product;
using Domain.Repositries.Common;
using MediatR;

namespace Application.CategoryUseCase.Queries;
public record GetCategoryProductsQuery(Guid CategoryId,PageRequest PageRequest) : IRequest<PageResult<ProductDto>>;
