using GithubAutomation.Pages;
using GithubAutomation.Workflows;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Tests
{
    [TestFixture]
    public class NewRepoTests : BaseSetup
    {
        /// <summary>
        /// Checks that a repository can be added.
        /// </summary>
        [Test]
        public void Can_Create_A_Repo()
        {
            RepoCreator.CreateRepo();

            Assert.AreEqual(RepoPage.Title, "TestRepo", "Failed to locate added repository.");
        }

        /// <summary>
        /// Checks that user can go to the Repositories page.
        /// </summary>
        [Test]
        public void Can_Go_To_Repos_Page()
        {
            RepoPage.GoToListOfRepos();
            Assert.IsTrue(RepoPage.IsAtListOfReposPage, "Failed to open the Repositories page.");
        }
        
        /// <summary>
        /// Checks that user has repositories.
        /// </summary>
        [Test]
        public void Have_Repos()
        {
            RepoPage.GoToListOfRepos();
            Assert.That(RepoPage.HaveRepos, "Failed to locate repositories.");
        }

        /// <summary>
        /// Checks that first repository from the list can be open.
        /// </summary>
        [Test]
        public void Can_Open_First_Repo_Page()
        {
            if (RepoPage.HaveRepos())
            {
                RepoPage.GoToFirstRepoPage();
            }

            Assert.That(RepoPage.IsAtFirstRepoPage, "Failed to open first repository from the list.");
        }

        /// <summary>
        /// Checks that particular repository can be open.
        /// </summary>
        [Test]
        public void Can_Open_Certain_Repo_Page()
        {
            if (RepoPage.DoesRepoExistWithTitle("TestRepo"))
            {
                RepoPage.GoToRepoPage("TestRepo");
            }

            Assert.That(RepoPage.Title.Equals("TestRepo"), "Failed to locate the repository.");
        }

        /// <summary>
        /// Checks that repository can be deleted.
        /// </summary>
        [Test]
        public void Can_Delete_Repo_Page()
        {
            RepoPage.GoToRepoPage("TestRepo");
            RepoPage.DeleteRepo("TestRepo");

            Assert.That(RepoPage.DeletedMessage.Contains("was successfully deleted."),
                "Failed to delete the repository.");
        }

        /// <summary>
        /// Checks that repository can be found when using search.
        /// </summary>
        [Test]
        public void Can_Search_Repos()
        {
            if (!RepoPage.DoesRepoExistWithTitle("TestRepo"))
            {
                RepoCreator.CreateRepo();
            }

            RepoPage.SearchForRepo("TestRepo");
            Assert.IsTrue(RepoPage.DoesRepoExistWithTitle("TestRepo"), "Failed to locate the repository.");
        }
    }
}