using CodeCraft.Domain.Entities;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Create;

public sealed class Handler(
    IProductRepository repository) : IRequestHandler<Command, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        Command request, 
        CancellationToken cancellationToken)
    {
        var creationResult = Product.Create(
            request.Name,
            request.Description,
            request.UserId);

        if(creationResult.IsFailed) return Result.Fail(creationResult.Errors);
        
        await repository.CreateAsync(creationResult.Value, cancellationToken);
        return creationResult.Value.Id;
    }
}