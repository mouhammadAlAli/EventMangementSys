using Application.CategoryUseCase.Command;
using Domain.Categories;
using Domain.Exceptions;
using Domain.Repositries;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryUseCase.Handler.CommandHandler
{
    public class DeleteCategoryCommandHandler : INotificationHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductSerivce _productSerivce;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(ICategoryService categoryService, IUnitOfWork unitOfWork, IProductSerivce productSerivce)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            _productSerivce = productSerivce;
        }

        public async Task Handle(DeleteCategoryCommand notification, CancellationToken cancellationToken)
        {
            var category = await _categoryService.FirstOrDefualt(c => c.Id == notification.CategoryId) ?? throw new NotFoundException(nameof(Category), notification.CategoryId.ToString());

            await _categoryService.Delete(notification.CategoryId);
            try
            {
                await _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new DomainException("Can't Delete");
            }
        }
    }
}
