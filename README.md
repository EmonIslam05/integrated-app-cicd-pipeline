# Integrated App — CI/CD Pipeline Simulation

A small C# solution that integrates three modules — **Login**, **Data
Processing**, and **Reporting** — into a single console application, plus a
GitHub Actions workflow that builds, tests, and deploys it.

## Solution layout

```
IntegratedApp/
├── IntegratedApp.sln
├── LoginModule/              # Authentication (class library)
├── DataProcessingModule/     # Aggregation logic (class library)
├── ReportingModule/          # Report formatting (class library, depends on the two above)
├── IntegratedApp.Console/    # Composition root / entry point (depends on all three)
└── IntegratedApp.Tests/      # xUnit unit + integration tests

.github/workflows/ci-cd.yml   # CI/CD pipeline configuration (GitHub Actions)
```

## Running locally

```bash
cd IntegratedApp
dotnet restore
dotnet build
dotnet test
dotnet run --project IntegratedApp.Console -- admin Admin123!
```

## Pipeline overview

The workflow in `.github/workflows/ci-cd.yml` has two jobs:

1. **build-and-test** — restores, builds, and runs the full test suite on
   every push and pull request; publishes test results and the built binary
   as pipeline artifacts.
2. **deploy** — runs only on pushes to `main`, and only if `build-and-test`
   passed, downloading the artifact and deploying it (placeholder step —
   swap in a real target such as Azure App Service, AWS, or SSH/SCP).

See `Integration_and_CICD_Report.docx` for the full write-up of the
integration approach, pipeline design, and challenges encountered.
