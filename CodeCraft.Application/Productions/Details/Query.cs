using CodeCraft.Query.Products.Details;
using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Details;

public sealed record Query(
    Guid Id) : IRequest<Result<Product>>;