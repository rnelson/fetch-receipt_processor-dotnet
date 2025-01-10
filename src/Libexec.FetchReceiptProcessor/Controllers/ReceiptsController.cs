using Libexec.FetchReceiptProcessor.Abstractions;
using Libexec.FetchReceiptProcessor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libexec.FetchReceiptProcessor.Controllers;

[Controller]
[Route("[controller]")]
public class ReceiptsController(IDatabase database)
{
    private readonly IDatabase _db = database ?? throw new ArgumentNullException(nameof(database));

    [HttpPost]
    public async Task<ActionResult<ProcessResponse>> Process([FromBody] Receipt receipt)
    {
        var id = await _db.AddReceiptAsync(receipt);
        return new ProcessResponse { Id = id };
    }
}