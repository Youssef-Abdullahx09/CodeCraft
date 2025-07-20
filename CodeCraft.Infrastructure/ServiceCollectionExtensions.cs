using CodeCraft.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCraft.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCodeCraftInfrastructure(
        this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddCodeCraftDbContext(configuration);
        return services;
    }

    private static void AddCodeCraftDbContext(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<ICodeCraftDbContext, CodeCraftDbContext>((sp, options) =>
            options.UseNpgsql(configuration.GetConnectionString(DbContextConfiguration.CodeCraftConnectionString)));

        var context = services.BuildServiceProvider().GetRequiredService<CodeCraftDbContext>();
        context.Database.Migrate();
    }   
}