using Application.ProductUseCase.Queries;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;

namespace Application.ProductUseCase.Handler.QueryHandler
{
    internal class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, PageResult<ProductDto>>
    {
        private readonly IProductSerivce _productSerivce;

        public GetProductByCategoryQueryHandler(IProductSerivce productSerivce)
        {
            _productSerivce = productSerivce;
        }

        public Task<PageResult<ProductDto>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            return _productSerivce.GetPage(request.PageRequest, c => c.CategoryId == request.CategoryId, c => c.Translations, c => c.CustomFieldValues.Select(c => c.CustomFieldKey.CustomField));
        }
    }
}
