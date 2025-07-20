namespace CodeCraft.Infrastructure.Utilities;

public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}