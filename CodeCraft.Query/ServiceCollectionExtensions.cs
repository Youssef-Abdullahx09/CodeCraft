using CodeCraft.Query.Utilities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace CodeCraft.Query;

public static class ServiceCollectionExtensions
{
    public static void AddCodeCraftQuery(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddSqlMappers();
        services.AddScoped<ICodeCraftQuery, CodeCraftQuery>();
        services.AddNpgConnection(configuration);
        
        services.AddScoped<IConnectionWrapper, ConnectionWrapper>();
        services.AddScoped<IQueryFileService, QueryFileService>();
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
            new NpgsqlConnection(configuration.GetConnectionString("CodeCraft")));
    }
}