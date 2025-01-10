namespace Libexec.FetchReceiptProcessor.Data;

public class ReceiptNotFoundException : Exception
{
    public ReceiptNotFoundException()
    {
    }

    public ReceiptNotFoundException(string? message) : base(message)
    {
    }

    public ReceiptNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}