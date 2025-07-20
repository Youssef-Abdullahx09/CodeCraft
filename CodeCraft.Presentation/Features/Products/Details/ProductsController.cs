using CodeCraft.Presentation.Utilities;
using CodeCraft.Query.Products.Details;
using Microsoft.AspNetCore.Mvc;

namespace CodeCraft.Presentation.Features.Products.Details;

[Tags("Products")]
[Route("products/{id:guid}")]
public sealed class ProductsController : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Details(
        [FromRoute] Guid id)
    {
        var result = await Sender.Send(
            new CodeCraft.Application.Productions.Details.Query(id),
            PipelineCancellationToken);
        
        return result.IsFailed ?
            BadRequest(result.Errors.FirstOrDefault()) 
            : Ok(result.Value);
    }
}