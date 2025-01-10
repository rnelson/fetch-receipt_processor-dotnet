using System.ComponentModel;
using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Data;

namespace Libexec.FetchReceiptProcessor.Models;

/// <inheritdoc/>
public class GetPointsResponse : IGetPointsResponse
{
    /// <inheritdoc/>
    [JsonRequired]
    [JsonPropertyName("points")]
    [Description("The number of points that were awarded.")]
    public int Points { get; set; }
}