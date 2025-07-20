using CodeCraft.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeCraft.Infrastructure;

public class CodeCraftDbContextFactory : IDesignTimeDbContextFactory<CodeCraftDbContext>
{
    public CodeCraftDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CodeCraftDbContext>();

        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), DbContextConfiguration.PathToPresentationLayer))
            .AddJsonFile(DbContextConfiguration.AppSettingFileName)
            .Build();

        // Get the connection string
        var connectionString = configuration.GetConnectionString(DbContextConfiguration.CodeCraftConnectionString);

        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException(DbContextConfiguration.ConnectionStringNotFound);

        optionsBuilder.UseNpgsql(connectionString);

        return new CodeCraftDbContext(optionsBuilder.Options);
    }
}