using GithubAutomation.Pages;
using GithubTests.Utilities;
using NUnit.Framework;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewIssuesTest : GithubTest
    {
        [Test]
        public void Can_Go_To_List_Of_Issues_Page()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            Assert.That(IssuePage.IsAt, "Failed to open Issues Page");
        }

        [Test]
        public void Can_Create_Issue()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            IssuePage.OpenNewIssueWindow();
            IssuePage
                .CreateIssue("Test Issue")
                .WithBody("This is the test body of issue")
                //change to your path to the file
                // you can leave it blank and nothing will be uploaded
                .UploadFile("//issue.txt")
                .Publish();

            IssuePage.GoToListOfIssues();

            Assert.That(IssuePage.Title.Contains("Test Issue"), "Issue was not created");
        }

        [Test]
        public void Added_Issue_Shows_Up()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.GoToRepoPage("TestRepo");
            IssuePage.GoToListOfIssues();
            IssuePage.CountIssues();

            IssuePage.OpenNewIssueWindow();
            IssuePage
                .CreateIssue("Test Issue")
                .WithBody("This is the test body of issue")
                //change to your path to the file
                // you can leave it blank and nothing will be uploaded
                .UploadFile("")
                .Publish();

            IssuePage.GoToListOfIssues();
            Assert.AreEqual(IssuePage.PreviousIssueCount + 1, IssuePage.CurrentIssueCount,
                "Count of issues did not increase");

            Assert.IsTrue(IssuePage.DoesIssueExistWithTitle("Test Issue"));

            IssuePage.DeleteIssue("Test Issue");
            Assert.AreEqual(IssuePage.PreviousIssueCount, IssuePage.CurrentIssueCount, "Could not delete issue");
        }
    }
}