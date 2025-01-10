using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Libexec.FetchReceiptProcessor.Abstractions;
using Libexec.FetchReceiptProcessor.Data;
using Libexec.FetchReceiptProcessor.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Libexec.FetchReceiptProcessor.Controllers;

[ApiController]
[Route("[controller]")]
public class ReceiptsController(IDatabase database) : ControllerBase
{
    private readonly IDatabase _db = database ?? throw new ArgumentNullException(nameof(database));

    [HttpPost("process")]
    [Consumes(MediaTypeNames.Application.Json)]
    [EndpointSummary("Submits a receipt for processing.")]
    [EndpointDescription("Submits a receipt for processing.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcessResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
    public async Task<ActionResult<ProcessResponse>> Process([FromBody] [Required] IReceipt? receipt)
    {
        if (receipt is null || !ModelState.IsValid)
            return BadRequest("The receipt is invalid.");
        
        var id = await _db.AddReceiptAsync(receipt);
        return new ProcessResponse { Id = id };
    }

    [HttpGet("{id:guid}/points")]
    [Consumes(MediaTypeNames.Application.Json)]
    [EndpointSummary("Returns the points awarded for the receipt.")]
    [EndpointDescription("Returns the points awarded for the receipt.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPointsResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
    public async Task<ActionResult<GetPointsResponse>> GetPoints([FromRoute] [Required] Guid id)
    {
        try
        {
            var points = await _db.GetPointsAsync(id);
            return new GetPointsResponse { Points = points };
        }
        catch (ReceiptNotFoundException)
        {
            return NotFound("No receipt found for that ID.");
        }
    }
}