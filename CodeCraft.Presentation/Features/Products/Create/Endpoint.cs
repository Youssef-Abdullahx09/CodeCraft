using CodeCraft.Presentation.Utilities;
using CodeCraft.Query.Products.Details;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Features.Products.Create;

[Tags("Products")]
[Route("products")]
public sealed class Endpoint : BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] Request request)
    {
        var result = await Sender.Send(
            request.ToCommand(CurrentUserId),
            PipelineCancellationToken);
        
        return result.IsFailed ?
            BadRequest(result.Errors.FirstOrDefault()) 
            : Ok(result.Value);
    }
}