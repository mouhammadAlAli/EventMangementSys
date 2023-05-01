using Domain.Categories;
using Domain.Products;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
}
