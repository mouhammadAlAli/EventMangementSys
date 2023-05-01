using Domain.Dtos.Product;
using Domain.Dtos.Product.CreateProductDtos;
using Domain.Products;

namespace Domain.Services
{
    public interface IProductSerivce:IGenaricSerivce<Product,ProductDto,CreateProductDto,UpdateProductDto>
    {
    }
}
