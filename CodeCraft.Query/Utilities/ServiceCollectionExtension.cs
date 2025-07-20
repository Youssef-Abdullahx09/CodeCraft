using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace CodeCraft.Query.Utilities;

public static class ServiceCollectionExtension
{
    public static void AddCodeCraftQuery(this IServiceCollection services,
        IConfiguration configuration)
    {
        AddSqlMappers();
        services.AddNpgConnection(configuration);
        services.AddConnectionWrapper();
    }

    private static void AddSqlMappers()
    {
        SqlMapper.AddTypeHandler(new DateTimeToStringConversion());
    }

    private static void AddNpgConnection(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<NpgsqlConnection>(_ =>
            new NpgsqlConnection(configuration.GetConnectionString("CodeCraftDB")));
    }

    public static IServiceCollection AddConnectionWrapper(
        this IServiceCollection services)
    {
        services.AddScoped<IConnectionWrapper, ConnectionWrapper>();

        return services;
    }
}