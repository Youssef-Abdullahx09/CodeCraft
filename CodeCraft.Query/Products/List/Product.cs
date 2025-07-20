namespace CodeCraft.Query.Products.List;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}