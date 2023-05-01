using Application.ProductUseCase.Queries;
using Domain.Dtos.Product;
using Domain.Exceptions;
using Domain.Services;
using MediatR;

namespace Application.ProductUseCase.Handler.QueryHandler
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductSerivce _productSerivce;

        public GetProductByIdHandler(IProductSerivce productSerivce)
        {
            _productSerivce = productSerivce;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productSerivce.FirstOrDefualt(c => c.Id == request.Id, c => c.Translations, c => c.CustomFieldValues.Select(c => c.CustomFieldKey.CustomField));
            if (product != null)
                return product;
            throw new NotFoundException(nameof(Domain.Products.Product), request.Id.ToString());
        }
    }
}
