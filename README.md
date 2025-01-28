# Web UI Testing Project

This project demonstrates automated testing of Web UI using C# and NUnit and Selenium.

---

### Getting started
1. **Install .NET 7+ and NuGet**
2. **Clone the repo**
3. **Install dependencies:**
   ```bash
   dotnet restore
   ```

### Running tests:
Execute command in the **ApiTests** folder

* run all tests:
   ```bash
   dotnet test
   ```

* run a single test:
   ```bash
   dotnet test --filter FullyQualifiedName=UiTests.Tests.GoogleSearchTests.GoogleSearchForPrometheusGroup

   ```

* run desired groups/tags:
   ```bash
   dotnet test --filter TestCategory=Smoke
   ```
---

### Test report
   - After running tests, detailed reports are saved in the `output/Reports` folder.
   - Open the report files to review test outcomes, errors, and execution times.


---

## **Useful Command Line Arguments:**

`--verbosity`  By default Playwright run headless mode. To run tests in headed mode, ex:
```bash
   dotnet test --verbosity detailed
```
