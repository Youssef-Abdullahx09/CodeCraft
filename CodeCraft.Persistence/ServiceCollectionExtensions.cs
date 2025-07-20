using CodeCraft.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCraft.Persistence;

public static class ServiceCollectionExtensions
{
    public static void AddCodeCraftPersistence(
        this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}