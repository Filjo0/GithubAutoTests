using GithubAutomation.Pages;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Tests
{
    [TestFixture]
    public class Tests : BaseSetup
    {
        /// <summary>
        /// Checks that user can login.
        /// </summary>
        [Test]
        public void User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}