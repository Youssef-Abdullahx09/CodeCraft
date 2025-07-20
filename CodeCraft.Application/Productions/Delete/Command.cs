using FluentResults;
using MediatR;

namespace CodeCraft.Application.Productions.Delete;

public sealed record Command(
    Guid Id,
    Guid UserId) : IRequest<Result>;