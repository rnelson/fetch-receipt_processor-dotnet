using Libexec.FetchReceiptProcessor.Data;

namespace Libexec.FetchReceiptProcessor.Tests;

public class ReceiptTests
{
    [Fact]
    public void Receipt_CalculatePoints_CorrectForTarget()
    {
        var receipt = new Receipt
        {
            Retailer = "Target",
            PurchaseDate = DateOnly.Parse("2022-01-01"),
            PurchaseTime = TimeOnly.Parse("13:01"),
            Total = 35.35m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "Mountain Dew 12PK", Price = 6.49m });
        receipt.Items.Add(new Item { ShortDescription = "Emils Cheese Pizza", Price = 12.25m });
        receipt.Items.Add(new Item { ShortDescription = "Knorr Creamy Chicken", Price = 1.26m });
        receipt.Items.Add(new Item { ShortDescription = "Doritos Nacho Cheese", Price = 3.35m });
        receipt.Items.Add(new Item { ShortDescription = "   Klarbrunn 12-PK 12 FL OZ  ", Price = 12.00m });
        
        Assert.Equal(28, receipt.CalculatePoints());
    }
    
    [Fact]
    public void Receipt_CalculatePoints_CorrectForMM()
    {
        var receipt = new Receipt
        {
            Retailer = "M&M Corner Market",
            PurchaseDate = DateOnly.Parse("2022-03-20"),
            PurchaseTime = TimeOnly.Parse("14:33"),
            Total = 9.00m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        
        Assert.Equal(109, receipt.CalculatePoints());
    }
}
