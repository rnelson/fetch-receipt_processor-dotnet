namespace Libexec.FetchReceiptProcessor.Extensions.Tests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("Target", 6)]
    [InlineData("M&M Corner Market", 14)]
    public void StringExtensions_SelectAlphanumericCharacters_Works(string s, int count)
    {
        var actual = s.SelectAlphanumericCharacters().Count();
        Assert.Equal(count, actual);
    }
}
