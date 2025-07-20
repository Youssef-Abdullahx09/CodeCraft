using System.Reflection;
using CodeCraft.Domain.Entities;
using CodeCraft.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeCraft.Infrastructure;

public sealed class CodeCraftDbContext(DbContextOptions<CodeCraftDbContext> options)
    : DbContext(options), ICodeCraftDbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema(SchemaConfiguration.SchemaName);
    }
}