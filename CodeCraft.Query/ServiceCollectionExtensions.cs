using CodeCraft.Query.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCraft.Query;

public static class ServiceCollectionExtensions
{
    public static void AddCodeCraftQuery(
        this IServiceCollection services)
    {
        services.AddScoped<ICodeCraftQuery, CodeCraftQuery>();
        
        services.AddScoped<IConnectionWrapper, ConnectionWrapper>();
    }
}