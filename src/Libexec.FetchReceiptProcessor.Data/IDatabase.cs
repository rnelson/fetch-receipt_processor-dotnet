namespace Libexec.FetchReceiptProcessor.Data;

/// <summary>
/// An interface to the database.
/// </summary>
public interface IDatabase
{
    /// <summary>
    /// Adds a receipt to the database.
    /// </summary>
    /// <param name="receipt">The receipt.</param>
    /// <returns>The unique ID of the added receipt.</returns>
    public Task<Guid> AddReceiptAsync(IReceipt receipt);

    /// <summary>
    /// Looks up the receipt by the ID and returns an object specifying the points awarded.
    /// </summary>
    /// <param name="receiptId">The receipt's ID.</param>
    /// <returns>The number of points awarded.</returns>
    public Task<int> GetPointsAsync(Guid receiptId);
}