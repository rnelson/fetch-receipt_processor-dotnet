using Libexec.FetchReceiptProcessor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libexec.FetchReceiptProcessor.Controllers;

[Controller]
[Route("[controller]")]
public class ReceiptsController
{
    [HttpPost]
    public async Task<ActionResult<ProcessResponse>> Process([FromBody] Receipt receipt)
    {
        return (ProcessResponse)null;
    }
}