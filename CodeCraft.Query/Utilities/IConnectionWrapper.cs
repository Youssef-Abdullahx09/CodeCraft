using System.Data;
using Dapper;

namespace CodeCraft.Query.Utilities;

public interface IConnectionWrapper
{
    ConnectionState State { get; }
    Task OpenAsync(CancellationToken cancellationToken);
    Task CloseAsync();
    
    Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default);
    
    Task<T?> QueryFirstOrDefaultAsync<T>(string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null, CancellationToken cancellationToken = default);
}