using GithubAutomation.Pages;
using GithubAutomation.Selenium;
using NUnit.Framework;

namespace GithubTests.Utilities
{
    [TestFixture]
    public class GithubTest
    {
        //change to your username and to your password
        private const string Username = "?";
        private const string Password = "?";

        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage
                .LoginAs(Username)
                .WithPassword(Password)
                .Login();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}