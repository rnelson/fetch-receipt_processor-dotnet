using System.Diagnostics.CodeAnalysis;

namespace Libexec.FetchReceiptProcessor.Abstractions;

/// <summary>
/// A single receipt.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IReceipt
{
    /// <summary>
    /// The name of the retailer or store the receipt is from.
    /// </summary>
    public string Retailer  { get; set; }
    
    /// <summary>
    /// The date of the purchase printed on the receipt.
    /// </summary>
    public DateOnly PurchaseDate { get; set; }
    
    /// <summary>
    /// The time of the purchase printed on the receipt. 24-hour time expected.
    /// </summary>
    public TimeOnly PurchaseTime { get; set; }

    /// <summary>
    /// The list of items purchased on the receipt.
    /// </summary>
    public List<IItem> Items { get; }

    /// <summary>
    /// The total amount paid on the receipt.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Calculates the number of points this receipt is worth.
    /// </summary>
    /// <returns>The number of points.</returns>
    public int CalculatePoints();
}