using GithubAutomation.Pages;
using GithubAutomation.Workflows;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewRepoTests : BaseSetup
    {
        [Test]
        public void Can_Create_A_Repo()
        {
            RepoCreator.CreateRepo();

            Assert.AreEqual(RepoPage.Title, "TestRepo", "Title did not match new repo");
        }

        [Test]
        public void Can_Go_To_Repos_Page()
        {
            RepoPage.GoToListOfRepos();
            Assert.IsTrue(RepoPage.IsAtListOfReposPage, "Failed to open Repos page");
        }

        [Test]
        public void User_Have_Repos()
        {
            RepoPage.GoToListOfRepos();
            Assert.That(RepoPage.HaveRepos, "No repos found!");
        }

        [Test]
        public void Can_Open_First_Repo_Page()
        {
            if (RepoPage.HaveRepos())
            {
                RepoPage.GoToFirstRepoPage();
            }

            Assert.That(RepoPage.IsAtFirstRepoPage, "Cannot open this page!");
        }

        [Test]
        public void Can_Open_Certain_Repo_Page()
        {
            if (RepoPage.DoesRepoExistWithTitle("TestRepo"))
            {
                RepoPage.GoToRepoPage("TestRepo");
            }

            Assert.That(RepoPage.Title.Equals("TestRepo"), "Repositories not found!");
        }

        [Test]
        public void Can_Delete_Repo_Page()
        {
            RepoPage.GoToRepoPage("TestRepo");
            RepoPage.DeleteRepo("TestRepo");

            Assert.That(RepoPage.DeletedMessage.Contains("was successfully deleted."),
                "Your repository was not deleted");
        }

        [Test]
        public void Can_Search_Repos()
        {
            // Check if Repo already exists
            if (!RepoPage.DoesRepoExistWithTitle("TestRepo"))
            {
                //create a new repo if does not exist
                RepoCreator.CreateRepo();
            }

            //Search for Repo
            RepoPage.SearchForRepo("TestRepo");
            //Check that repo shows up in results
            Assert.IsTrue(RepoPage.DoesRepoExistWithTitle("TestRepo"), "Repository does not exist!");
        }
    }
}