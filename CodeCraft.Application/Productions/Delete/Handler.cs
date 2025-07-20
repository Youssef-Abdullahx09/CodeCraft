using CodeCraft.Domain.Entities;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Delete;

public sealed class Handler(
    IProductRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle(
        Command request, 
        CancellationToken cancellationToken)
    {
        // could've used hard delete but i prefer soft deletion for logging
        
        var productResult = await repository.GetByIdAsync(request.Id, cancellationToken);
        if(productResult.IsFailed) return Result.Fail(productResult.Errors);
        
        var product = productResult.Value;
        
        var deleteResult = product.Delete(request.UserId);
        if(deleteResult.IsFailed) return Result.Fail(deleteResult.Errors);

        await repository.UpdateAsync(product, cancellationToken);
        return Result.Ok();
    }
}