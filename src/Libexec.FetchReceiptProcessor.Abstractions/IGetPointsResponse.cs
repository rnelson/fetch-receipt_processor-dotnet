using System.Diagnostics.CodeAnalysis;

namespace Libexec.FetchReceiptProcessor.Abstractions;

/// <summary>
/// Response for `/receipts/{id}/points`
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IGetPointsResponse
{
    /// <summary>
    /// The number of points that were awarded.
    /// </summary>
    public int Points { get; set; }
}