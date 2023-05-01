using Application.ProductUseCase.Command;
using Domain.Exceptions;
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
    internal class DeleteProductCommandHandler : INotificationHandler<DeleteProductCommand>
    {
        private readonly IProductSerivce _productSerivce;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductSerivce productSerivce, IUnitOfWork unitOfWork)
        {
            _productSerivce = productSerivce;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand notification, CancellationToken cancellationToken)
        {
            var product = await _productSerivce.FirstOrDefualtEntity(c => c.Id == notification.productId);
            if (product == null)
                throw new NotFoundException(nameof(Domain.Products.Product), notification.productId.ToString());
            _productSerivce.Delete(product);
            await _unitOfWork.SaveChanges();

        }

 
    }
}
