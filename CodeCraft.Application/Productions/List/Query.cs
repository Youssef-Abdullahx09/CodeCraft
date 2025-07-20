using CodeCraft.Query.Products.List;
using CodeCraft.Query.Utilities;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.List;

public sealed record Query : BaseQueryList, IRequest<Result<PaginationList<Product>>>
{
    public string? Name { get; init; } = string.Empty;
}