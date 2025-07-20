using CodeCraft.Infrastructure;
using CodeCraft.Persistence;
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
    }
}