using System.Text;
using DataProcessingModule;
using LoginModule;

namespace ReportingModule;

public interface IReportGenerator
{
    string GenerateReport(AuthenticationResult user, ProcessingResult data);
}

/// <summary>
/// Turns the output of the LoginModule and DataProcessingModule into a
/// human-readable report. This module is intentionally the "integration
/// point" of the sample application: it depends on the other two modules'
/// public contracts (AuthenticationResult, ProcessingResult) and nothing
/// else, which is what keeps the three modules loosely coupled.
/// </summary>
public class ReportGenerator : IReportGenerator
{
    public string GenerateReport(AuthenticationResult user, ProcessingResult data)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(data);

        var sb = new StringBuilder();
        sb.AppendLine("=====================================");
        sb.AppendLine(" SALES SUMMARY REPORT");
        sb.AppendLine("=====================================");
        sb.AppendLine($"Generated for : {user.UserName} ({user.Role})");
        sb.AppendLine($"Generated at  : {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
        sb.AppendLine("-------------------------------------");
        sb.AppendLine($"Records processed : {data.RecordCount}");
        sb.AppendLine($"Total amount      : {data.TotalAmount:C}");
        sb.AppendLine($"Average amount    : {data.AverageAmount:C}");
        sb.AppendLine("-------------------------------------");
        sb.AppendLine("Totals by region:");

        foreach (var (region, amount) in data.TotalsByRegion.OrderByDescending(kv => kv.Value))
        {
            sb.AppendLine($"  {region,-15} {amount,10:C}");
        }

        sb.AppendLine("=====================================");
        return sb.ToString();
    }
}
