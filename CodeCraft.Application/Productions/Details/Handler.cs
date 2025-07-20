using CodeCraft.Query;
using CodeCraft.Query.Products.Details;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Details;

public sealed class Handler(
    ICodeCraftQuery codeCraftQuery) : IRequestHandler<Query, Result<Product>>
{
    public async Task<Result<Product>> Handle(
        Query request,
        CancellationToken cancellationToken)
    {
        return await codeCraftQuery.ProductDetails(
            new CodeCraft.Query.Products.Details.Query(request.Id),
            cancellationToken);
    }
}