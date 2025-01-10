using Libexec.FetchReceiptProcessor.Models;

namespace Libexec.FetchReceiptProcessor.Tests;

public class ProcessResponseTests
{
    [Fact]
    public void ProcessResponse_Constructor_Works()
    {
        _ = new ProcessResponse();
    }
    
    [Fact]
    public void ProcessResponse_IdSetterAndGetter_Work()
    {
        var expected = Guid.NewGuid();

        var response = new ProcessResponse { Id = expected };

        Assert.Equal(expected, response.Id);
    }
}
