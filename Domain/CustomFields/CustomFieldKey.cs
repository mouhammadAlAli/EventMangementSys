using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CustomFields
{
    public class CustomFieldKey : BaseEntity
    {
        public Guid CustomFieldId { get; set; }
        [ForeignKey(nameof(CustomFieldId))]
        public virtual CustomField CustomField { get; set; }
        public string Key { get; set; }
    }
}
