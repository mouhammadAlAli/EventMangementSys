using Domain.CustomFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfiguration
{
    internal class CustomFieldKeyConfiguration : IEntityTypeConfiguration<CustomFieldKey>
    {
        public void Configure(EntityTypeBuilder<CustomFieldKey> builder)
        {
            builder.HasData(new CustomFieldKey()
            {
                Id = new Guid("991cd085-9877-493c-838b-31689d030a84"),
                Key = "engine size",
                CustomFieldId = new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91")
            });
            builder.HasData(new CustomFieldKey()
            {
                Id = new Guid("991cd085-9877-493c-838b-31689d030a86"),
                Key = "engine type",
                CustomFieldId = new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91")
            });
            builder.HasData(new CustomFieldKey()
            {
                Id = new Guid("991cd085-9877-493c-838b-31689d030a87"),
                Key = "Type",
                CustomFieldId = new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b29")
            });
        }
    }
}
