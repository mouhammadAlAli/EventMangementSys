using AutoMapper;
using Domain.Categories;
using Domain.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    internal class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
