using Application.ProductUseCase.Command;
using Domain.Repositries;
using Domain.Services;
using MediatR;

namespace Application.ProductUseCase.Handler.CommandHandler
{
    internal class CreateProductCommandHandler : INotificationHandler<CreateProductCommand>
    {
        private readonly IProductSerivce _productSerivce;
        private readonly ICustomFeildService _customFeildService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductSerivce productSerivce, IUnitOfWork unitOfWork, ICustomFeildService customFeildService)
        {
            _productSerivce = productSerivce;
            _unitOfWork = unitOfWork;
            _customFeildService = customFeildService;
        }

        public async Task Handle(CreateProductCommand notification, CancellationToken cancellationToken)
        {
            var customFeilds = notification.CreateProductDto.CustomFeilds;
            await _customFeildService.CreateAndUpdateCustomFiledWithKeyes(customFeilds);
            await _productSerivce.Create(notification.CreateProductDto);
            await _unitOfWork.SaveChanges();
        }
    }
}
