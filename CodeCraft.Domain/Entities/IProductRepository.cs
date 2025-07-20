using FluentResults;

namespace CodeCraft.Domain.Entities;

public interface IProductRepository
{
    Task<Result<Product>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task CreateAsync(
        Product product,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Product product,
        CancellationToken cancellationToken = default);
}