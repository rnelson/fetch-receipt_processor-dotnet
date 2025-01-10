using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Abstractions;

namespace Libexec.FetchReceiptProcessor.Data;

/// <inheritdoc/>
public class Item : IItem
{
    /// <inheritdoc/>
    [JsonRequired]
    [JsonPropertyName("shortDescription")]
    [Description("The Short Product Description for the item.")]
    [RegularExpression(@"^[\\w\\s\\-]+$")]
    public required string ShortDescription { get; set; }
    
    /// <inheritdoc/>
    [JsonRequired]
    [JsonPropertyName("price")]
    [Description("The total price paid for this item.")]
    [RegularExpression(@"^\\d+\\.\\d{2}$")]
    public required decimal Price { get; set; }
}