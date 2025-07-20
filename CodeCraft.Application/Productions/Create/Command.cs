using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Create;

public sealed record Command(
    string Name,
    string Description,
    Guid UserId) : IRequest<Result<Guid>>;