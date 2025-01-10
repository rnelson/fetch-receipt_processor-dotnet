namespace Libexec.FetchReceiptProcessor.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Selects all alphanumeric characters in <paramref name="s"/>.
    /// </summary>
    /// <param name="s">The string.</param>
    /// <returns>An enumerable list of all alphanumeric characters in the string.</returns>
    /// <remarks>This is using Unicode, not ASCII, to determine alphanumeric.</remarks>
    public static IEnumerable<char> SelectAlphanumericCharacters(this string s) =>
        s.ToCharArray().Where(char.IsLetterOrDigit);
}