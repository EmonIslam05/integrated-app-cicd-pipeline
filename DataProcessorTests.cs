using DataProcessingModule;
using Xunit;

namespace IntegratedApp.Tests;

public class DataProcessorTests
{
    private readonly IDataProcessor _processor = new DataProcessor();

    [Fact]
    public void Process_EmptyInput_ReturnsZeroedResult()
    {
        var result = _processor.Process(new List<SalesRecord>());

        Assert.Equal(0, result.RecordCount);
        Assert.Equal(0m, result.TotalAmount);
        Assert.Empty(result.TotalsByRegion);
    }

    [Fact]
    public void Process_MultipleRecords_ComputesTotalsAndAverage()
    {
        var records = new List<SalesRecord>
        {
            new("North", "Widget", 100m),
            new("North", "Gadget", 50m),
            new("South", "Widget", 150m),
        };

        var result = _processor.Process(records);

        Assert.Equal(3, result.RecordCount);
        Assert.Equal(300m, result.TotalAmount);
        Assert.Equal(100m, result.AverageAmount);
        Assert.Equal(150m, result.TotalsByRegion["North"]);
        Assert.Equal(150m, result.TotalsByRegion["South"]);
    }

    [Fact]
    public void Process_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _processor.Process(null!));
    }
}
