using GithubAutomation.Pages;
using GithubAutomation.Selenium;
using GithubAutomation.Workflows;
using NUnit.Framework;

namespace GithubTests.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();

            RepoCreator.Initialize();

            LoginPage.GoTo();
            LoginPage
                .LoginAs(Driver.Username)
                .WithPassword(Driver.Password)
                .Login();
        }

        [TearDown]
        public void CleanUp()
        {
            RepoCreator.CleanUp();
            Driver.Close();
        }
    }
}