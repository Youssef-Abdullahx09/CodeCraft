using System.Data;
using CodeCraft.Query.Utilities;
using Dapper;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace CodeCraft.Query;

public sealed class CodeCraftQuery(
    IConnectionWrapper connectionWrapper,
    IQueryFileService queryFileService,
    ILogger<CodeCraftQuery> logger) : ICodeCraftQuery
{
    private const string QuerySql = "Query.sql";
    public async Task<Result<PaginationList<Products.List.Product>>> ListProducts(
        Products.List.Query query,
        CancellationToken cancellationToken = default)
    {
        try
        {
            long recordsCount = 0;
            if (connectionWrapper.State != ConnectionState.Open)
                await connectionWrapper.OpenAsync(cancellationToken);

            var queryFilePathResult = await queryFileService.ReadFileContentAsync(cancellationToken, 
                    nameof(Products),
                    nameof(Products.List),
                    QuerySql);

            if (queryFilePathResult.IsFailed)
                return Result.Fail(queryFilePathResult.Errors);

            var queryParameters = new DynamicParameters();
            queryParameters.Add(nameof(query.Name), query.Name?.Trim());
            
            // queryParameters.Add(nameof(query.OrderBy), query.OrderBy);
            queryParameters.Add(nameof(query.SortDirection), query.SortDirection.GetValue());
            queryParameters.Add(nameof(query.PageNumber), query.PageNumber);
            queryParameters.Add(nameof(query.PageSize), query.PageSize);

            var result = await connectionWrapper
                .QueryAsync<Products.List.Product, long, Products.List.Product>(
                queryFilePathResult.Value,
                (product, totalCount) =>
                {
                    recordsCount = totalCount;
                    return product;
                },
                splitOn: "Total", 
                param: queryParameters,
                cancellationToken: cancellationToken);

            return Result.Ok(new PaginationList<Products.List.Product>(result, recordsCount));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Message}", ex.Message);
            return Result.Fail<PaginationList<Products.List.Product>>(ErrorMessages.LoadingProducts);
        }
        finally
        {
            if (connectionWrapper.State != ConnectionState.Closed)
                await connectionWrapper.CloseAsync();
        }    
    }

    public async Task<Result<Products.Details.Product>> ProductDetails(
        Products.Details.Query query,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (connectionWrapper.State != ConnectionState.Open)
                await connectionWrapper.OpenAsync(cancellationToken);

            var queryFilePathResult = await queryFileService.ReadFileContentAsync(cancellationToken, 
                nameof(Products),
                nameof(Products.Details),
                QuerySql);

            if (queryFilePathResult.IsFailed) return Result.Fail(queryFilePathResult.Errors);

            var queryParameters = new DynamicParameters();
            queryParameters.Add(nameof(query.Id), query.Id);

            var product = await connectionWrapper
                .QueryFirstOrDefaultAsync<Products.Details.Product>(
                    queryFilePathResult.Value,
                    param: queryParameters,
                    cancellationToken: cancellationToken);

            return product is null ? Result.Fail(ErrorMessages.ProductNotFound) : product;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Message}", ex.Message);
            return Result.Fail(ErrorMessages.LoadingProduct);
        }
        finally
        {
            if (connectionWrapper.State != ConnectionState.Closed)
                await connectionWrapper.CloseAsync();
        }
    }
}