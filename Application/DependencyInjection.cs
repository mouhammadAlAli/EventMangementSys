using Application.Services;
using Domain.Authontication;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection InjectApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection));
        services.AddScoped(typeof(IGenaricSerivce<,,,>), typeof(GenaricSerivce<,,,>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEventService, EventService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
