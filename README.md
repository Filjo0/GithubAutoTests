# GithubAutoTests
Selenium project written in C# and based on the NUnit framework (Page Object Model pattern).
The project also includes the log4net logging.

### Tests:
- Login page:
    - Login
- Repositories page:
    - Create Repository
    - Delete Repository
    - Search Repository
- Issues Page
    - Create Issue
    - Delete issue
    - Search Issue

#### Running Tests
- Install Google Chrome
- Update Chrome driver in NuGet Packages if needed
- Add your username and password in GithubTests -> Utilities -> BaseSetup.cs
- Run tests from GithubTests -> Tests
