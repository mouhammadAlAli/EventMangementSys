using Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfiguration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Products).WithOne(c => c.Category).HasForeignKey(c=>c.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            var data = new List<Category>
            {
                new Category()
                {

                    Id =new  Guid("c77e3e74-22ff-4032-aa44-716ca223f7bf"),
                    Name = "Car",
                    CreatedOnUtc = new DateTime(2023,1,1),
                    CreatedBy = "System",

                },
                new Category()
                {
                    Id =new Guid("aa78790e-9d22-4243-a735-f96ac103d491"),
                    Name = "House",
                    CreatedOnUtc = new DateTime(2023,1,1),
                    CreatedBy = "System",

                }
            };
            builder.HasData(data);
        }
    }
}
