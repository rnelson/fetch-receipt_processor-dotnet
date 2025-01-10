namespace Libexec.FetchReceiptProcessor.Data.Tests;

public class DatabaseTests
{
    [Fact]
    public void Database_Constructor_Works()
    {
        _ = new Database();
    }

    [Fact]
    public async Task Database_AddReceiptAsync_Works()
    {
        var db = new Database();
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new() { ShortDescription = "NIKKOR Z 85mm f/1.8", Price = 899.99m });
        _ = await db.AddReceiptAsync(receipt);
    }

    [Fact]
    public async Task Database_GetPointsAsync_Works()
    {
        var db = new Database();
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new() { ShortDescription = "NIKKOR Z 85mm f/1.8       ", Price = 899.99m });
        var id = await db.AddReceiptAsync(receipt);
        
        // Score:
        //   Name: 15 points
        //   Round dollar: 0 points
        //   Multiple of quarter: 0 points
        //   Item pairs: 0 points
        //   Trimmed desc: 0 points
        //   LLM: 0 points
        //   Purchase date: 6 points
        //   Purchase time: 10 points
        // ---------------------------------
        // = 15+6+10 = 31

        var points = await db.GetPointsAsync(id);
        Assert.Equal(31, points);
    }

    [Fact]
    public async Task Database_GetPointsAsync_ThrowsExceptionWhenNotFound()
    {
        var db = new Database();
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new() { ShortDescription = "NIKKOR Z 85mm f/1.8       ", Price = 899.99m });
        _ = await db.AddReceiptAsync(receipt);

        await Assert.ThrowsAsync<ReceiptNotFoundException>(() => db.GetPointsAsync(Guid.NewGuid()));
    }
}
