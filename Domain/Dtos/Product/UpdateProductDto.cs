using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos.Product.CreateProductDtos;

namespace Domain.Dtos.Product
{
    public class UpdateProductDto:CreateProductDto
    {
        public Guid Id { get; set; }
        public UpdateProductDto(CreateProductDto createProductDto,Guid Id)
        {
            this.Id= Id;
            this.CreateProductTranslationDto = createProductDto.CreateProductTranslationDto;
            this.Price= createProductDto.Price;
            this.DurationInDays= createProductDto.DurationInDays;
            this.CategoryId= createProductDto.CategoryId;
            this.CustomFeilds= createProductDto.CustomFeilds;
            this.StartAppearingDate= createProductDto.StartAppearingDate;
        }
    }
}
