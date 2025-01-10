using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Libexec.FetchReceiptProcessor.Models;

public class Receipt
{
    [JsonRequired]
    [JsonPropertyName("retailer")]
    [Description("The name of the retailer or store the receipt is from.")]
    [RegularExpression(@"^[\\w\\s\\-&]+$")]
    public required string Retailer { get; set; }
    
    [JsonIgnore]
    [Description("The date of the purchase printed on the receipt.")]
    public required DateOnly PurchaseDate { get; set; }
    
    [JsonIgnore]
    [Description("The time of the purchase printed on the receipt. 24-hour time expected.")]
    public required DateOnly PurchaseTime { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("items")]
    [Description("The list of items purchased on the receipt.")]
    [MinLength(1)]
    public List<Item> Items { get; private set; } = [];
    
    [JsonRequired]
    [JsonPropertyName("total")]
    [Description("The total amount paid on the receipt.")]
    [RegularExpression(@"^\\d+\\.\\d{2}$")]
    public required decimal Total { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("purchaseDate")]
    private string PurchaseDateString => PurchaseDate.ToString("yyyy-MM-dd");
    
    [JsonRequired]
    [JsonPropertyName("purchaseTime")]
    private string PurchaseTimeString => PurchaseTime.ToString("HH:mm");
}