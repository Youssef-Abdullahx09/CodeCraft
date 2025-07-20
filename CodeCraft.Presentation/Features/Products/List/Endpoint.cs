using CodeCraft.Presentation.Utilities;
using CodeCraft.Query.Products.List;
using CodeCraft.Query.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Features.Products.List;

[Tags("Products")]
[Route("products")]
public sealed class Endpoint : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<Product>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> List(
        [FromQuery] CodeCraft.Application.Productions.List.Query query)
    {
        var result = await Sender.Send(query, PipelineCancellationToken);
        
        return result.IsFailed ?
            BadRequest(result.Errors.FirstOrDefault()) 
            : Ok(result.Value);
    }
}