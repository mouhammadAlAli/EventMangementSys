using AutoMapper;
using Domain.Categories;
using Domain.Dtos.Category;
using Domain.Repositries;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class CategoryService : GenaricSerivce<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>,ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
