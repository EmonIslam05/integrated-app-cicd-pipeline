namespace DataProcessingModule;

/// <summary>
/// Aggregated output of the data-processing module. This is the contract
/// the ReportingModule consumes, so the two modules only need to agree on
/// this shape, not on how the aggregation happens internally.
/// </summary>
public sealed record ProcessingResult(
    int RecordCount,
    decimal TotalAmount,
    decimal AverageAmount,
    IReadOnlyDictionary<string, decimal> TotalsByRegion);
