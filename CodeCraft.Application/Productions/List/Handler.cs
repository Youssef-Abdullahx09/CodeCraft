using CodeCraft.Query;
using CodeCraft.Query.Products.List;
using CodeCraft.Query.Utilities;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.List;

public sealed class Handler(
    ICodeCraftQuery codeCraftQuery) : IRequestHandler<Query, Result<PaginationList<Product>>>
{
    public async Task<Result<PaginationList<Product>>> Handle(
        Query request,
        CancellationToken cancellationToken)
    {
        return await codeCraftQuery.ListProducts(
            new CodeCraft.Query.Products.List.Query
            {
                Name = request.Name,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SortDirection = request.SortDirection,
                OrderBy = request.SortOptions.ToString() ?? nameof(SortOptions.Name)
            },
            cancellationToken);
    }
}