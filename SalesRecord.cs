namespace DataProcessingModule;

/// <summary>
/// A single raw input row. In a real system this would be read from a
/// database, CSV import, or upstream API; here it is a plain POCO so the
/// module has no dependency on any particular data source.
/// </summary>
public sealed record SalesRecord(string Region, string Product, decimal Amount);
