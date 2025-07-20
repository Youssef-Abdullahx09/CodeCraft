using CodeCraft.Domain.Entities;
using CodeCraft.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Infrastructure;

public interface ICodeCraftDbContext : IDbContext
{
    public DbSet<Product> Products { get; }
}