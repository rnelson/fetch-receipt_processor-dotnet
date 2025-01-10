namespace Libexec.FetchReceiptProcessor.Abstractions.Tests;

public class ReceiptNotFoundException
{
    [Fact]
    public void ReceiptNotFoundException_Constructor_Works()
    {
        var e = new Abstractions.ReceiptNotFoundException();
        
        Assert.NotNull(e);
    }
    
    [Fact]
    public void ReceiptNotFoundException_ConstructorWithMessage_Works()
    {
        const string expected = "No receipt found for that ID.";
        var e = new Abstractions.ReceiptNotFoundException(expected);
        
        Assert.NotNull(e);
        Assert.Equal(expected, e.Message);
    }
    
    [Fact]
    public void ReceiptNotFoundException_ConstructorWithMessageAndInnerException_Works()
    {
        const string expected = "No receipt found for that ID.";
        
        var inner = new Exception();
        var e = new Abstractions.ReceiptNotFoundException(expected, inner);
        
        Assert.NotNull(e);
        Assert.NotNull(e.InnerException);
        Assert.Equal(expected, e.Message);
    }
}
