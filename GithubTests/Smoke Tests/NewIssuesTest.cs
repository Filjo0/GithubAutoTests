using GithubAutomation.Pages;
using GithubAutomation.Workflows;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewIssuesTest : BaseSetup
    {
        [Test]
        public void Can_Go_To_List_Of_Issues_Page()
        {
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            Assert.That(IssuePage.IsAt, "Failed to open Issues Page");
        }

        [Test]
        public void Can_Create_Issue()
        {
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();

            IssueCreator.CreateIssue();

            IssuePage.GoToListOfIssues();

            Assert.IsTrue(IssuePage.DoesIssueExistWithTitle(IssueCreator.IssueTitle), "Issue does not exist");
        }

        [Test]
        public void Added_Issue_Shows_Up()
        {
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            IssuePage.CountIssues();

            IssueCreator.CreateIssue();

            IssuePage.GoToListOfIssues();
            Assert.AreEqual(IssuePage.PreviousIssueCount + 1, IssuePage.CurrentIssueCount,
                "Count of issues did not increase");

            Assert.IsTrue(IssuePage.DoesIssueExistWithTitle("Test Issue"), "Issue does not exist");

            IssuePage.DeleteIssue(IssueCreator.IssueTitle);
            Assert.AreEqual(IssuePage.PreviousIssueCount, IssuePage.CurrentIssueCount, "Could not delete issue");
        }

        [Test]
        public void Can_Search_Issues()
        {
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();

            //Search for Issue
            IssuePage.SearchForIssue("Test Issue");

            // Check if Repo already exists
            if (!IssuePage.FoundOpenIssues())
            {
                //create a new issue if does not exist
                IssueCreator.CreateIssue();
                IssuePage.GoToListOfIssues();
            }

            //Check that Issue shows up in results
            Assert.IsTrue(IssuePage.DoesIssueExistWithTitle("Test Issue"), "Issue does not exist");

            //Cleanup
            IssuePage.DeleteIssue("Test Issue");
            Assert.IsFalse(IssuePage.DoesIssueExistWithTitle("Test Issue"), "Issue was not deleted");
        }
    }
}