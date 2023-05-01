using Domain.CustomFields;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TypeConfiguration
{
    internal class CustomFieldConfiguration : IEntityTypeConfiguration<CustomField>
    {
        public void Configure(EntityTypeBuilder<CustomField> builder)
        {
            builder.HasData(new CustomField()
            {
                Id = new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b29"),
                Name = "House Fields",
                CreatedBy = "System",
                CreatedOnUtc = DateTime.UtcNow,
            });
            builder.HasData(new CustomField()
            {
                Id = new Guid("d84ec479-b38d-433f-ba57-2d3d2e4a3b91"),
                Name = "Engine specs",
                CreatedBy = "System",
                CreatedOnUtc = DateTime.UtcNow,
            });
        }
    }
}
