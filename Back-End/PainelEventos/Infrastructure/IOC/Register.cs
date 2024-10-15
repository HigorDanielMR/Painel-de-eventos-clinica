using System.Reflection;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IOC;

public static class Register
{
    public static IServiceCollection RegistrarDepencias(this IServiceCollection services)
    {
        services.RegistrarDbContext();

        services.RegisterApplication(Assembly.Load("Application"));

        services.RegisterRepository(assemblyInterfaces: Assembly.Load("Domain"), assemblyImplementations: Assembly.Load("Infrastructure"));

        return services;
    }

    private static IServiceCollection RegistrarDbContext(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("BancoEmMemoria"));

        return services;
    }
}
