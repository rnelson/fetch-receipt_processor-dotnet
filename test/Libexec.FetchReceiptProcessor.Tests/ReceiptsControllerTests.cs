using Libexec.FetchReceiptProcessor.Controllers;
using Libexec.FetchReceiptProcessor.Data;
using Libexec.FetchReceiptProcessor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libexec.FetchReceiptProcessor.Tests;

public class ReceiptsControllerTests
{
    private readonly Database _db = new();
    
    [Fact]
    public async Task ReceiptsController_Process_Works()
    {
        var controller = new ReceiptsController(_db);
        var response = await controller.Process(CreateReceipt());

        Assert.IsType<ProcessResponse>(response.Value);

        // Make sure we got a valid GUID back
        _ = Guid.Parse(response.Value!.Id.ToString());
    }
    
    [Fact]
    public async Task ReceiptsController_Process_ReturnsBadRequestOnBadRequest()
    {
        var controller = new ReceiptsController(_db);
        var response = await controller.Process(null!);
        
        Assert.IsType<BadRequestObjectResult>(response.Result);
    }
    
    [Fact]
    public async Task ReceiptsController_GetPoints_Works()
    {
        var controller = new ReceiptsController(_db);
        var response = await controller.Process(CreateReceipt());

        Assert.IsType<ProcessResponse>(response.Value);
        var addedGuid = Guid.Parse(response.Value!.Id.ToString());
        
        var pointsResponse = await controller.GetPoints(addedGuid);
        Assert.NotNull(pointsResponse);
        Assert.True(pointsResponse.Value!.Points > 0);
    }
    
    [Fact]
    public async Task ReceiptsController_GetPoints_ReturnsNotFoundOnMissingGuid()
    {
        var controller = new ReceiptsController(_db);
        var addedResponse = await controller.Process(CreateReceipt());

        Assert.IsType<ProcessResponse>(addedResponse.Value);
        _ = Guid.Parse(addedResponse.Value!.Id.ToString());
        var newGuid = Guid.NewGuid();
        
        var searchResponse = await controller.GetPoints(newGuid);
        Assert.IsType<NotFoundObjectResult>(searchResponse.Result);
    }

    private static Receipt CreateReceipt()
    {
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "NIKKOR Z 85mm f/1.8", Price = 899.99m });
        
        return receipt;
    }
}