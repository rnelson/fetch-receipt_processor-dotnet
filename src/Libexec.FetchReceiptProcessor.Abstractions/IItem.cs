using System.Diagnostics.CodeAnalysis;

namespace Libexec.FetchReceiptProcessor.Abstractions;

/// <summary>
/// A single item on a receipt.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
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