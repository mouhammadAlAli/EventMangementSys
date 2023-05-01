
using Domain.Translations;
namespace Domain.Products
{
    public class ProductTranslation : Translation<Product, Guid>
    {
        public string Name { get; set; }
    }
}
