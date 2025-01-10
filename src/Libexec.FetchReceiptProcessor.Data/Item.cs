using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Libexec.FetchReceiptProcessor.Data;

/// <summary>
/// A single item on a receipt.
/// </summary>
public class Item
{
    /// <summary>
    /// The Short Product Description for the item.
    /// </summary>
    [JsonRequired]
    [JsonPropertyName("shortDescription")]
    [Description("The Short Product Description for the item.")]
    [RegularExpression(@"^[\w\s\-]+$")]
    public required string ShortDescription { get; set; }
    
    /// <summary>
    /// The total price paid for this item.
    /// </summary>
    [JsonRequired]
    [JsonPropertyName("price")]
    [Description("The total price paid for this item.")]
    [RegularExpression(@"^\d+\.\d{2}$")]
    public required decimal Price { get; set; }
}