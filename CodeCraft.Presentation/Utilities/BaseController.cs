using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Utilities;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private ISender? _sender;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>()!;

    private IHttpContextAccessor? Accessor => !HttpContext.Response.HasStarted
        ? HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>()
        : null;

    protected CancellationToken PipelineCancellationToken => Accessor?.HttpContext?.RequestAborted ?? default;

    protected Guid CurrentUserId => Guid.NewGuid();
}