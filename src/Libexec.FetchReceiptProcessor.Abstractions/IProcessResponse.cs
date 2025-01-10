namespace Libexec.FetchReceiptProcessor.Abstractions;

/// <summary>
/// Response for `/receipts/process`
/// </summary>
public interface IProcessResponse
{
    /// <summary>
    /// The ID for the receipt.
    /// </summary>
    public Guid Id { get; set; }
}