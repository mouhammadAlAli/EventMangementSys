using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjection));
            services.AddScoped(typeof(IGenaricSerivce<,,,>), typeof(GenaricSerivce<,,,>));
            services.AddScoped<IProductSerivce, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomFeildService, CustomFeildService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
