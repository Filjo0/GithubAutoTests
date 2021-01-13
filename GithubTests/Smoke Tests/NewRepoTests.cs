using GithubAutomation;
using GithubAutomation.Pages;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewRepoTests : GithubTest
    {
        [Test]
        public void Can_Create_A_Repo()
        {
            NewRepoPage.GoTo();
            NewRepoPage
                .CreateRepo("TestRepo")
                .WithDescription("Hi, this is the description.")
                .IsPrivate(true)
                .Publish();

            Assert.AreEqual(RepoPage.Title, "TestRepo", "Title did not match new repo");
        }

        [Test]
        public void Can_Go_To_Repos_Page()
        {
            RepoPage.GoToListOfRepos();
            Assert.IsTrue(RepoPage.IsAt, "Failed to open Repos page");
        }

        [Test]
        public void Can_Delete_Repo_Page()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.OpenRepoPage("TestRepo");
            RepoPage.DeleteRepo();

            Assert.That(RepoPage.DeletedMessage.Contains("was successfully deleted."),
                "Your repository was not deleted");
        }
    }
}