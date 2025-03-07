using System.ComponentModel;
using System.Text.Json.Serialization;
using Libexec.FetchReceiptProcessor.Data;

namespace Libexec.FetchReceiptProcessor.Models;

public class DeleteReceiptResponse : IDeleteReceiptResponse
{
    /// <inheritdoc/>
    [JsonRequired]
    [JsonPropertyName("deleted")]
    [Description("Flag indicating whether or not the receipt was successfully deleted.")]
    public bool Deleted { get; set; }
    
    /// <inheritdoc/>
    [JsonRequired]
    [JsonPropertyName("points")]
    [Description("The ID of the receipt that was requested to be deleted.")]
    public Guid ReceiptId { get; set; }
}