using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repositries;
using Infrastructure.Repositries;

namespace Infrastructure.Extensions;


public static class DependencyInjection
{
    public static IServiceCollection InjectInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}

