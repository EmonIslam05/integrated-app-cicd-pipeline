# Integrated App — CI/CD Pipeline Simulation

A C# console application demonstrating **modular application integration** and an automated **CI/CD pipeline using GitHub Actions**.

The project integrates three core modules — **Login, Data Processing, and Reporting** — into a single application. It also includes unit and integration tests and a GitHub Actions workflow for automated build, testing, and deployment.

---

## 📌 Project Overview

The objective of this project is to demonstrate how multiple C# modules can be integrated into one application and how the development workflow can be automated using CI/CD practices.

The application performs the following operations:

1. User authentication
2. Data processing and aggregation
3. Report generation
4. Automated unit and integration testing
5. Continuous Integration using GitHub Actions
6. Automated deployment workflow

---

## 🛠️ Technologies Used

* **C#**
* **.NET**
* **.NET CLI**
* **xUnit**
* **GitHub**
* **GitHub Actions**
* **CI/CD**
* **Object-Oriented Programming**

---

## 📂 Project Structure

```text
IntegratedApp/
│
├── IntegratedApp.sln
│
├── LoginModule/
│   ├── LoginModule.csproj
│   ├── IUserAuthenticator.cs
│   └── UserAuthenticator.cs
│
├── DataProcessingModule/
│   ├── DataProcessingModule.csproj
│   ├── DataProcessor.cs
│   ├── ProcessingResult.cs
│   └── SalesRecord.cs
│
├── ReportingModule/
│   ├── ReportingModule.csproj
│   └── ReportGenerator.cs
│
├── IntegratedApp.Console/
│   ├── IntegratedApp.Console.csproj
│   └── Program.cs
│
├── IntegratedApp.Tests/
│   ├── IntegratedApp.Tests.csproj
│   ├── UserAuthenticatorTests.cs
│   ├── DataProcessorTests.cs
│   └── IntegrationTests.cs
│
├── .github/
│   └── workflows/
│       └── ci-cd.yml
│
├── .gitignore
└── README.md
```

---

## 🔹 Application Modules

### 1. Login Module

Responsible for user authentication.

**Main responsibilities:**

* Validate user credentials
* Authenticate application users
* Return authentication results
* Provide a reusable authentication interface

---

### 2. Data Processing Module

Responsible for processing and aggregating application data.

**Main responsibilities:**

* Process sales records
* Perform data aggregation
* Calculate processing results
* Return structured processing information

---

### 3. Reporting Module

Responsible for generating reports from processed information.

**Main responsibilities:**

* Receive processed data
* Format the results
* Generate readable reports
* Integrate information from other modules

---

### 4. Console Application

The console application acts as the **composition root** of the project.

It connects the Login, Data Processing, and Reporting modules and provides the main application entry point.

---

### 5. Testing Module

The project includes automated tests using **xUnit**.

Tests cover:

* Authentication functionality
* Data processing functionality
* Module integration
* Expected application behaviour

---

# 🚀 Getting Started

## Prerequisites

Install the following software before running the project:

* [.NET SDK](https://dotnet.microsoft.com/download)
* Git
* A code editor such as Visual Studio or Visual Studio Code

---

## 📥 Clone the Repository

```bash
git clone https://github.com/EmonIslam05/integrated-app-cicd-pipeline.git
```

Navigate to the project directory:

```bash
cd integrated-app-cicd-pipeline
```

---

## 🔄 Restore Dependencies

```bash
dotnet restore
```

---

## 🔨 Build the Solution

```bash
dotnet build
```

---

## 🧪 Run Tests

Execute all unit and integration tests:

```bash
dotnet test
```

A successful test run confirms that the implemented modules are working as expected.

---

## ▶️ Run the Application

Run the console application using:

```bash
dotnet run --project IntegratedApp.Console -- admin Admin123!
```

The application then performs authentication, data processing, and report generation.

---

# 🔄 CI/CD Pipeline

The project uses **GitHub Actions** to automate the software development workflow.

The workflow is defined in:

```text
.github/workflows/ci-cd.yml
```

### Pipeline Flow

```text
Developer Push / Pull Request
              │
              ▼
       GitHub Actions
              │
              ▼
        Restore Project
              │
              ▼
          Build Code
              │
              ▼
        Run Test Suite
              │
        ┌─────┴─────┐
        │           │
      Failed      Passed
        │           │
        ▼           ▼
      Stop       Build Artifact
                    │
                    ▼
              Deploy Job
                    │
                    ▼
              Deployment
```

---

## ⚙️ CI Job — Build and Test

The CI stage automatically:

1. Checks out the source code
2. Restores .NET dependencies
3. Builds the solution
4. Runs unit tests
5. Runs integration tests
6. Publishes test results
7. Creates a build artifact

This job runs on **pushes and pull requests**.

---

## 🚀 CD Job — Deployment

The deployment stage runs after the build-and-test job succeeds.

It is configured to run for pushes to the `main` branch.

The current deployment step acts as a **deployment placeholder** and can later be connected to services such as:

* Azure App Service
* AWS
* Virtual machines
* SSH/SCP-based servers
* Other cloud deployment platforms

---

# 🧪 Testing

The project follows an automated testing approach using **xUnit**.

### Test Categories

| Test Type         | Purpose                                            |
| ----------------- | -------------------------------------------------- |
| Unit Tests        | Test individual module functionality               |
| Integration Tests | Verify communication between modules               |
| CI Tests          | Automatically execute tests through GitHub Actions |

Run all tests with:

```bash
dotnet test
```

---

# 🔐 Authentication

For local demonstration, the application accepts the following sample credentials:

```text
Username: admin
Password: Admin123!
```

> **Note:** These credentials are intended only for demonstration purposes. Production applications should never store or expose credentials directly in source code.

---

# 📊 Key Features

* Modular C# architecture
* Login/authentication module
* Data processing module
* Reporting module
* Console-based application
* Unit testing
* Integration testing
* Automated CI pipeline
* Automated deployment workflow
* GitHub Actions integration
* Build artifact generation

---

# 🎯 Project Objectives

The main objectives of this project are:

* Understand modular software architecture
* Integrate multiple C# projects into a single solution
* Implement automated testing
* Understand Continuous Integration
* Understand Continuous Deployment
* Configure GitHub Actions workflows
* Automate build and test processes
* Prepare an application for cloud/server deployment

---

# 📈 Future Improvements

The project can be extended with:

* Database integration
* Secure password hashing
* JWT-based authentication
* REST API implementation
* Web-based user interface
* Real cloud deployment
* Docker containerization
* Code coverage reporting
* Static code analysis
* Security scanning
* Environment-based configuration
* Automated release management

---

# 👨‍💻 Author

**Mir Mosaraf Hossain**

BCA Student
School of Engineering
Sister Nivedita University

### GitHub

https://github.com/EmonIslam05

### Project Repository

https://github.com/EmonIslam05/integrated-app-cicd-pipeline

---

# 📄 Project Documentation

The detailed project report contains information about:

* Application integration approach
* Module architecture
* CI/CD pipeline design
* Testing strategy
* Implementation details
* Challenges encountered
* Future improvements

---

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

## ⭐ Conclusion

This project demonstrates the integration of multiple C# modules into a single console application while applying modern software development practices.

By combining **modular architecture, automated testing, GitHub Actions, Continuous Integration, and Continuous Deployment**, the project provides a practical demonstration of a complete software development and delivery workflow.

See `Integration_and_CICD_Report.docx` for the full write-up of the
integration approach, pipeline design, and challenges encountered.
