using CodeCraft.Application.Productions.Delete;
using CodeCraft.Presentation.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Features.Products.Delete;

[Tags("Products")]
[Route("products/{id:guid}")]
public sealed class Endpoint : BaseController
{
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id)
    {
        var result = await Sender.Send(
            new Command(id, CurrentUserId),
            PipelineCancellationToken);
        
        return result.IsFailed ?
            BadRequest(result.Errors.FirstOrDefault()) : NoContent();
    }
}