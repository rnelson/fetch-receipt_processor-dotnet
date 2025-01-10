namespace Libexec.FetchReceiptProcessor.Data.Tests;

public class ReceiptTests
{
    [Fact]
    public void Receipt_CalculatePoints_CorrectForTarget()
    {
        var receipt = new Receipt
        {
            Retailer = "Target",
            PurchaseDate = "2022-01-01",
            PurchaseTime = "13:01",
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
            PurchaseDate = "2022-03-20",
            PurchaseTime = "14:33",
            Total = 9.00m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        receipt.Items.Add(new Item { ShortDescription = "Gatorade", Price = 2.25m });
        
        Assert.Equal(109, receipt.CalculatePoints());
    }
    
    [Fact]
    public void Receipt_PurchaseDateString_Works()
    {
        const string expected = "2022-08-17";
        
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "NIKKOR Z 85mm f/1.8", Price = 899.99m });

        Assert.Equal(expected, receipt.PurchaseDate);
    }
    
    [Fact]
    public void Receipt_PurchaseTimeString_Works()
    {
        const string expected = "15:42";
        
        var receipt = new Receipt
        {
            Retailer = "Rockbrook Camera",
            PurchaseDate = "2022-08-17",
            PurchaseTime = "15:42",
            Total = 946.18m
        };
        
        receipt.Items.Add(new Item { ShortDescription = "NIKKOR Z 85mm f/1.8", Price = 899.99m });

        Assert.Equal(expected, receipt.PurchaseTime);
    }
}