using System.Diagnostics.CodeAnalysis;

namespace Libexec.FetchReceiptProcessor.Data;

/// <summary>
/// Response for `/receipts/process`
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IProcessResponse
{
    /// <summary>
    /// The ID for the receipt.
    /// </summary>
    public Guid Id { get; set; }
}