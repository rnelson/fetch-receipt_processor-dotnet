namespace Libexec.FetchReceiptProcessor.Data;

public interface IDeleteReceiptResponse
{
    public bool Deleted { get; set; }
    
    public Guid ReceiptId { get; set; }
}