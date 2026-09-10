using DataProcessingModule;
using LoginModule;
using ReportingModule;

namespace IntegratedApp.Console;

/// <summary>
/// Composition root: this is the only place in the solution that knows
/// about all three modules. Each module is instantiated behind its
/// interface, so any module could later be replaced (e.g. UserAuthenticator
/// swapped for an OAuth-based implementation) without changing this file's
/// structure, only the object that gets constructed here.
/// </summary>
public static class Program
{
    public static int Main(string[] args)
    {
        // 1. Resolve dependencies (manual composition; a larger app would
        //    use Microsoft.Extensions.DependencyInjection instead).
        IUserAuthenticator authenticator = new UserAuthenticator();
        IDataProcessor processor = new DataProcessor();
        IReportGenerator reportGenerator = new ReportGenerator();

        // 2. Module 1: Login
        var username = args.Length > 0 ? args[0] : "admin";
        var password = args.Length > 1 ? args[1] : "Admin123!";

        var authResult = authenticator.Authenticate(username, password);
        System.Console.WriteLine(authResult.Message);

        if (!authResult.Success)
        {
            return 1; // non-zero exit code so a CI pipeline can fail fast
        }

        // 3. Module 2: Data processing
        var sampleData = new List<SalesRecord>
        {
            new("North", "Widget", 1200.50m),
            new("South", "Widget", 950.00m),
            new("North", "Gadget", 430.75m),
            new("East",  "Widget", 1875.25m),
            new("West",  "Gadget", 610.10m),
            new("South", "Gadget", 725.40m),
        };

        var processingResult = processor.Process(sampleData);

        // 4. Module 3: Reporting (consumes the outputs of modules 1 and 2)
        var report = reportGenerator.GenerateReport(authResult, processingResult);
        System.Console.WriteLine(report);

        return 0;
    }
}
