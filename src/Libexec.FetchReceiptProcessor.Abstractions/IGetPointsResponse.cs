﻿namespace Libexec.FetchReceiptProcessor.Abstractions;

/// <summary>
/// Response for `/receipts/{id}/points`
/// </summary>
public interface IGetPointsResponse
{
    /// <summary>
    /// The number of points that were awarded.
    /// </summary>
    public int Points { get; set; }
}