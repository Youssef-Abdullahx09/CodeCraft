using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Update;

public sealed record Command(
    Guid Id,
    string Name,
    string Description,
    Guid UserId) : IRequest<Result>;