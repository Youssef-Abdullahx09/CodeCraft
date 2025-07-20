using FluentResults;

namespace CodeCraft.Query.Utilities;

public interface IQueryFileService
{
    public Task<Result<string>> ReadFileContentAsync(
        CancellationToken cancellationToken,
        params string[] path);
}