using CodeCraft.Presentation.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Features.Products.Update;

[Tags("Products")]
[Route("products/{id:guid}")]
public sealed class Endpoint : BaseController
{
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] Request request)
    {
        var result = await Sender.Send(
            request.ToCommand(id, CurrentUserId),
            PipelineCancellationToken);
        
        return result.IsFailed ?
            BadRequest(result.Errors.FirstOrDefault()) : NoContent();
    }
}