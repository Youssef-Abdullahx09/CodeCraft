using CodeCraft.Domain.Entities;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Update;

public sealed class Handler(
    IProductRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle(
        Command request, 
        CancellationToken cancellationToken)
    {
        var productResult = await repository.GetByIdAsync(request.Id, cancellationToken);
        if(productResult.IsFailed) return Result.Fail(productResult.Errors);
        
        var product = productResult.Value;
        
        var updateResult = product.Update(
            request.Name,
            request.Description,
            request.UserId);
        
        if(updateResult.IsFailed) return Result.Fail(updateResult.Errors);

        await repository.UpdateAsync(product, cancellationToken);
        return Result.Ok();
    }
}