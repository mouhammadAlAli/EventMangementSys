using Domain.Dtos.Category;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryUseCase.Queries
{
    public record GetCategoryQuery(PageRequest PageRequest) : IRequest<PageResult<CategoryDto>>;
}
