using CodeCraft.Application.Productions.Update;

namespace CodeCraft.Presentation.Features.Products.Update;

public sealed record Request(
    string Name,
    string Description)
{
    public Command ToCommand(
        Guid productId,
        Guid userId) => new Command(
        productId,
        Name,
        Description,
        userId);
}