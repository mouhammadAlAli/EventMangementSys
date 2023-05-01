using Application.ProductUseCase.Queries;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductUseCase.Handler.QueryHandler
{
    internal class GetProductHandler : IRequestHandler<GetProductQuery, PageResult<ProductDto>>
    {
        private readonly IProductSerivce _productSerivce;

        public GetProductHandler(IProductSerivce productSerivce)
        {
            _productSerivce = productSerivce;
        }

        public Task<PageResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = _productSerivce.GetPage(request.PageRequest, null, c => c.Translations, c => c.CustomFieldValues.Select(c => c.CustomFieldKey.CustomField));
            return data;
        }
    }
}
