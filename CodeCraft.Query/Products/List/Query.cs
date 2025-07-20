using CodeCraft.Query.Utilities;

namespace CodeCraft.Query.Products.List;

public sealed record Query : BaseQueryList
{
    public string? Name { get; init; }
    public string? OrderBy { get; init; }
}