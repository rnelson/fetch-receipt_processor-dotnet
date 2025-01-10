using Libexec.FetchReceiptProcessor.Abstractions;

namespace Libexec.FetchReceiptProcessor.Data;

/// <inheritdoc/>
public class Database : IDatabase
{
    private readonly Dictionary<Guid, IReceipt> _receipts = [];
    
    /// <inheritdoc/>
    public Task<Guid> AddReceiptAsync(IReceipt receipt)
    {
        var id = Guid.NewGuid();
        _receipts.Add(id, receipt);
        
        return Task.FromResult(id);
    }

    /// <inheritdoc/>
    public Task<int> GetPoints(Guid receiptId)
    {
        if (!_receipts.TryGetValue(receiptId, out var receipt))
            throw new ReceiptNotFoundException($"receipt with id {receiptId} not found");
        
        return Task.FromResult(receipt.CalculatePoints());
    }
}
