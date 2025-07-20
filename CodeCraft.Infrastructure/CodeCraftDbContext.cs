using System.Reflection;
using CodeCraft.Domain.Entities;
using CodeCraft.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Infrastructure;

public sealed class CodeCraftDbContext : DbContext, ICodeCraftDbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema(SchemaConfiguration.SchemaName);
    }
}