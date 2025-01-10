namespace Libexec.FetchReceiptProcessor.Data.Tests;

public class ReceiptNotFoundExceptionTests
{
    [Fact]
    public void ReceiptNotFoundException_Constructor_Works()
    {
        var e = new ReceiptNotFoundException();
        
        Assert.NotNull(e);
    }
    
    [Fact]
    public void ReceiptNotFoundException_ConstructorWithMessage_Works()
    {
        const string expected = "No receipt found for that ID.";
        var e = new ReceiptNotFoundException(expected);
        
        Assert.NotNull(e);
        Assert.Equal(expected, e.Message);
    }
    
    [Fact]
    public void ReceiptNotFoundException_ConstructorWithMessageAndInnerException_Works()
    {
        const string expected = "No receipt found for that ID.";
        
        var inner = new Exception();
        var e = new ReceiptNotFoundException(expected, inner);
        
        Assert.NotNull(e);
        Assert.NotNull(e.InnerException);
        Assert.Equal(expected, e.Message);
    }
}
