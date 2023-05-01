using Domain.Base;

namespace Domain.CustomFields
{
    public class CustomField : AggregateEntity
    {
        public string Name { get; set; }
        public virtual List<CustomFieldKey> CustomFieldKeys { get; set; }
    }
}
