using Libexec.FetchReceiptProcessor.Models;

namespace Libexec.FetchReceiptProcessor.Tests;

public class GetPointsResponseTests
{
    [Fact]
    public void GetPointsResponse_Constructor_Works()
    {
        _ = new GetPointsResponse();
    }
    
    [Fact]
    public void GetPointsResponse_PointsSetterAndGetter_Work()
    {
        const int expected = 42;

        var response = new GetPointsResponse { Points = expected };

        Assert.Equal(expected, response.Points);
    }
}
