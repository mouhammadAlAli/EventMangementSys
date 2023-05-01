using Domain.Base;
using Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CustomFields
{
    public class CustomFieldValue:BaseEntity
    {
        public Guid CustomFieldKeyId { get; set; }
        [ForeignKey(nameof(CustomFieldKeyId))]
        public CustomFieldKey CustomFieldKey { get; set; }
        public Guid ProducId { get; set; }
        [ForeignKey(nameof(ProducId))]
        public Product Product { get; set; }
        public string Value { get; set; }
    }
}
