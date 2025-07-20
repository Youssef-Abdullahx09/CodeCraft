using CodeCraft.Query.Utilities;
using FluentResults;

namespace CodeCraft.Query;

public interface ICodeCraftQuery
{
    Task<Result<PaginationList<Products.List.Product>>> ListProducts(
        Products.List.Query query,
        CancellationToken cancellationToken = default);   
    
    Task<Result<Products.Details.Product>> ProductDetails(
        Products.Details.Query query,
        CancellationToken cancellationToken = default);
}