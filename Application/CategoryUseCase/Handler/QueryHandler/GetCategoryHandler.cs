using Application.CategoryUseCase.Queries;
using Domain.Dtos.Category;
using Domain.Repositries.Common;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryUseCase.Handler.QueryHandler
{
    internal class GetCategoryHandler : IRequestHandler<GetCategoryQuery, PageResult<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Task<PageResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _categoryService.GetPage(request.PageRequest,null);
        }
    }
}
