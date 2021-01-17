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
    }
}