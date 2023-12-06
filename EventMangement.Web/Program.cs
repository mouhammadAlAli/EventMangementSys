using Application;
using FlashProduct.Web.Middlewares;
using Infrastructure.Extensions;
using Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Authontication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Name="Token",
        //Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                                     {
                                                         { jwtSecurityScheme, Array.Empty<string>() }
                                                     });
});
builder.Services.InjectInfrastructure(builder.Configuration);
builder.Services.InjectApplication();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    DataInitializer.SeedLocal(dbContext);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
