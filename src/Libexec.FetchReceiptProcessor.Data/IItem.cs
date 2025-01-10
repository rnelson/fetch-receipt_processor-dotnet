using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Data;

namespace Libexec.FetchReceiptProcessor.Data;

/// <summary>
/// A single item on a receipt.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[JsonDerivedType(typeof(Item))]
[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
public interface IItem
{
    /// <summary>
    /// The Short Product Description for the item.
    /// </summary>
    public string ShortDescription { get; set; }
    
    /// <summary>
    /// The total price paid for this item.
    /// </summary>
    public decimal Price { get; set; }
}