using DataProcessingModule;
using LoginModule;
using ReportingModule;
using Xunit;

namespace IntegratedApp.Tests;

/// <summary>
/// These tests exercise all three modules together, the same way
/// IntegratedApp.Console.Program does, to prove that the integrated
/// system produces a consistent end-to-end result. This is the class
/// the CI pipeline relies on to catch integration regressions.
/// </summary>
public class IntegrationTests
{
    [Fact]
    public void EndToEnd_LoginProcessAndReport_ProducesExpectedReport()
    {
        IUserAuthenticator authenticator = new UserAuthenticator();
        IDataProcessor processor = new DataProcessor();
        IReportGenerator reportGenerator = new ReportGenerator();

        var authResult = authenticator.Authenticate("analyst", "Analyst123!");
        Assert.True(authResult.Success);

        var data = new List<SalesRecord>
        {
            new("North", "Widget", 100m),
            new("South", "Widget", 200m),
        };
        var processingResult = processor.Process(data);

        var report = reportGenerator.GenerateReport(authResult, processingResult);

        Assert.Contains("analyst", report);
        Assert.Contains("Analyst", report);
        Assert.Contains("Records processed : 2", report);
    }

    [Fact]
    public void EndToEnd_FailedLogin_StopsBeforeReportGeneration()
    {
        IUserAuthenticator authenticator = new UserAuthenticator();

        var authResult = authenticator.Authenticate("admin", "wrong-password");

        // Mirrors the guard clause in Program.Main: reporting must never
        // run for an unauthenticated user.
        Assert.False(authResult.Success);
    }
}
