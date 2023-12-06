using Domain;
using Domain.Authontication;
using Domain.Roles;
using Domain.Users;
using System.Data;

namespace Infrastructure.Helper;

public static class DataInitializer
{
    private const string SystemCreatedBy = "system";
    private readonly static DateTime DefaultCreatedDate = new DateTime(2023, 5, 12);

    public static void SeedLocal(ApplicationDbContext applicationDbContext)
    {
       if (!applicationDbContext.Roles.Any())
        {
            var roles = new List<Role> 
            {
                new Role()
                {
                    Name = AppConsts.UserRole,
                CreatedBy = SystemCreatedBy,
                CreatedOnUtc = DefaultCreatedDate,
                },
                 new Role()
                {
                Name = AppConsts.EventMangerRole,
                CreatedBy = SystemCreatedBy,
                CreatedOnUtc = DefaultCreatedDate,
                }
            };
            applicationDbContext.Roles.AddRange(roles);
            applicationDbContext.SaveChanges();
        }

        if (!applicationDbContext.Users.Any())
        {
            var mangerRole = applicationDbContext.Roles.First(x=>x.Name == AppConsts.EventMangerRole);
            var userRole = applicationDbContext.Roles.First(x => x.Name == AppConsts.UserRole);
            var users = new List<User>
                {
                    new User
                    {
                    Name = "Admin",
                    Email = "Admin@test.com",
                    Password = PasswordHasher.HashPassword("123qwe"),
                    Role = mangerRole
                    }, new User
                    {
                    Name = "Mohammad",
                    Email = "mmm@test.com",
                    Password = PasswordHasher.HashPassword("123qwe"),
                    Role = userRole
                    }
                };
            applicationDbContext.Users.AddRange(users);
            applicationDbContext.SaveChanges();
        }
    }
}
