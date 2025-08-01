using System.Reflection;
using CodeCraft.Infrastructure;
using CodeCraft.Persistence;
using CodeCraft.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCraft.Application;

public static class ServiceCollectionExtensions
{
    public static void AddCodeCraftApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCodeCraftInfrastructure(configuration);
        services.AddCodeCraftPersistence();
        services.AddCodeCraftQuery(configuration);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}