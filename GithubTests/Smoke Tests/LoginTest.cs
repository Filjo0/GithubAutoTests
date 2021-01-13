using GithubAutomation;
using GithubAutomation.Pages;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class Tests : GithubTest
    {
        [Test]
        public void User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}