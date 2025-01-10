using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Data;

namespace Libexec.FetchReceiptProcessor.Models;

/// <inheritdoc/>
public class ProcessResponse : IProcessResponse
{
    /// <inheritdoc/>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}