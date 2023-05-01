using Domain.Base;
using Domain.Products;

namespace Domain.Categories
{
    public class Category : AggregateEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
