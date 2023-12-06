using Domain.Events;
using Domain.Roles;
using Domain.Users;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles {  get; set; }
    public virtual DbSet<Event> Events {  get; set; }
    public virtual DbSet<EventTranslation> EventTranslations {  get; set; }

    
}
