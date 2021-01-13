using GithubAutomation.Pages;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewIssuesTest
    {
        [Test]
        public void Can_Go_To_List_Of_Issues_Page()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.OpenRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            Assert.That(IssuePage.IsAt, "Failed to open Issues Page");
        }

        [Test]
        public void Can_Create_Issue()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.OpenRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            IssuePage.CreateIssue();

            Assert.That(IssuePage.Title.Contains("Name of Issue"), "Issue was not created");
        }
    }
}