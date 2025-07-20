using CodeCraft.Application.Productions.Create;

namespace CodeCraft.Presentation.Features.Products.Create;

public sealed record Request(
    string Name,
    string Description)
{
    public Command ToCommand(
        Guid userId) => new Command(
        Name,
        Description,
        userId);
}