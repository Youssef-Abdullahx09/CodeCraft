using FluentResults;

namespace CodeCraft.Query.Utilities;

public class QueryFileService : IQueryFileService
{
    public async Task<Result<string>> ReadFileContentAsync(
        CancellationToken cancellationToken,
        params string[] path)
    {
        var queryFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, 
            Path.Combine(path));

        if (!File.Exists(queryFilePath))
            return Result.Fail("File path not found.");

        var sqlQuery = await File.ReadAllTextAsync(queryFilePath, cancellationToken);
        return Result.Ok(sqlQuery);
    }
}