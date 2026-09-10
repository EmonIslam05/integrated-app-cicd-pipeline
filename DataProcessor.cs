namespace DataProcessingModule;

public interface IDataProcessor
{
    ProcessingResult Process(IEnumerable<SalesRecord> records);
}

/// <summary>
/// Performs simple aggregation over a set of sales records. Deliberately
/// framework-free and side-effect-free (pure function) so it is trivial
/// to unit test and to run inside a CI pipeline without external services.
/// </summary>
public class DataProcessor : IDataProcessor
{
    public ProcessingResult Process(IEnumerable<SalesRecord> records)
    {
        ArgumentNullException.ThrowIfNull(records);

        var list = records.ToList();

        if (list.Count == 0)
        {
            return new ProcessingResult(0, 0m, 0m, new Dictionary<string, decimal>());
        }

        var total = list.Sum(r => r.Amount);
        var average = total / list.Count;
        var byRegion = list
            .GroupBy(r => r.Region)
            .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

        return new ProcessingResult(list.Count, total, average, byRegion);
    }
}
