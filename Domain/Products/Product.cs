using Domain.Base;
using Domain.Categories;
using Domain.CustomFields;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Products;

public class Product : AggregateEntity
{
    public ICollection<ProductTranslation> Translations { get; set; }
    public ICollection<CustomFieldValue> CustomFieldValues { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public DateTime StartAppearingDate{ get; set; }
    public int DurationInDays { get; set; }
    public double Price { get; set; }
}
