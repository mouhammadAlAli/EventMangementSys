using Application.ProductUseCase.Queries;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;

namespace Application.ProductUseCase.Handler.QueryHandler;

internal class GetProductBasedOnCurrentTimeQueryHandler : IRequestHandler<GetProductBasedOnCurrentTimeQuery, PageResult<ProductDto>>
{
    private readonly IProductSerivce _productSerivce;

    public GetProductBasedOnCurrentTimeQueryHandler(IProductSerivce productSerivce)
    {
        _productSerivce = productSerivce;
    }

    public Task<PageResult<ProductDto>> Handle(GetProductBasedOnCurrentTimeQuery request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow.Date;
        return _productSerivce.GetPage(request.PageRequest, x => now >= x.StartAppearingDate.Date && now < x.StartAppearingDate.AddDays(x.DurationInDays).Date, c => c.Translations, c => c.CustomFieldValues.Select(c => c.CustomFieldKey.CustomField));
    }
}
