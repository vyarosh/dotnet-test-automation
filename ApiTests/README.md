# REST API Testing Project

This project demonstrates automated testing of REST APIs using C# and NUnit. It utilizes the [JSONPlaceholder](https://jsonplaceholder.typicode.com/) API for mock data, covering CRUD operations (GET, POST, PUT, DELETE).

---

### Getting started
1. **Install .NET 7+ and NuGet**
2. **Clone the repo**
3. **Install dependencies:**
   ```bash
   dotnet restore
   ```
4. **Update the API base URL**
   Edit `config.json` to configure the base URL for the JSONPlaceholder API:
   ```json
   {
     "BaseUrl": "https://jsonplaceholder.typicode.com"
   }
   ```


### Running tests:
Execute command in the **ApiTests** folder

* run all tests:
   ```bash
   dotnet test
   ```

* run a single test:
   ```bash
   dotnet test --filter FullyQualifiedName=RestApiTests.Tests.JsonPlaceApiTests.GetReturnsPostsArrayTest
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
