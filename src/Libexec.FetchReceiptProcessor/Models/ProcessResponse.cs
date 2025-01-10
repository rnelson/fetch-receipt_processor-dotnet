using System.Text.Json.Serialization;

namespace Libexec.FetchReceiptProcessor.Models;

public class ProcessResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}