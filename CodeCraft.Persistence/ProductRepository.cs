using CodeCraft.Domain.Entities;
using CodeCraft.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CodeCraft.Persistence;

public sealed class ProductRepository(
    ICodeCraftDbContext dbContext) : IProductRepository
{
    public async Task<Result<Product>> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        var product = await dbContext.Products
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (product is null) return Result.Fail(ErrorMessages.ProductNotFound);
        
        return Result.Ok(product);
    }

    public async Task CreateAsync(
        Product product,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Products.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);       
    }

    public async Task UpdateAsync(
        Product product, 
        CancellationToken cancellationToken = default)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);       
    }
}