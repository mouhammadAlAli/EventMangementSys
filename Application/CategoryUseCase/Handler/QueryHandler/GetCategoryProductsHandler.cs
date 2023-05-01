using Application.CategoryUseCase.Queries;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;

namespace Application.CategoryUseCase.Handler.QueryHandler
{
    public class GetCategoryProductsHandler : IRequestHandler<GetCategoryProductsQuery, PageResult<ProductDto>>
    {
        private readonly IProductSerivce _productSerivce;

        public GetCategoryProductsHandler(IProductSerivce productSerivce)
        {
            _productSerivce = productSerivce;
        }

        public async Task<PageResult<ProductDto>> Handle(GetCategoryProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productSerivce.GetPage(request.PageRequest,x=>x.CategoryId == request.CategoryId,c=>c.Translations,c=>c.CustomFieldValues);
        }
    }
}
