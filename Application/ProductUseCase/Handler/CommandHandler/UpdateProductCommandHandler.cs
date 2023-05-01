using Application.Services;
using Domain.Repositries;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductUseCase.Handler.CommandHandler
{
    internal class UpdateProductCommandHandler : INotificationHandler<UpdateProductCommand>
    {
        private readonly IProductSerivce _productSerivce;
        private readonly ICustomFeildService _customFeildService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductSerivce productSerivce, IUnitOfWork unitOfWork, ICustomFeildService customFeildService)
        {
            _productSerivce = productSerivce;
            _unitOfWork = unitOfWork;
            _customFeildService = customFeildService;
        }

        public async Task Handle(UpdateProductCommand notification, CancellationToken cancellationToken)
        {
           await  _customFeildService.CreateAndUpdateCustomFiledWithKeyes(notification.UpdateProductDto.CustomFeilds);

            await _productSerivce.Update(notification.UpdateProductDto);
            await _unitOfWork.SaveChanges();
        }
    }
}
