using Domain.Categories;
using Domain.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICategoryService: IGenaricSerivce<Category, CategoryDto,CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
