using GithubAutomation.Pages;

namespace GithubAutomation.Workflows
{
    public static class IssueCreator
    {
        public static void CreateIssue()
        {
            IssuePage.OpenNewIssueWindow();

            IssueTitle = "Test Issue";
            IssueBody = "This is the test body of issue";
            //change to your path to the file
            // you can leave it blank and nothing will be uploaded
            IssueFile = "";


            IssuePage
                .CreateIssue(IssueTitle)
                .WithBody(IssueBody)
                .UploadFile(IssueFile)
                .Publish();
        }

        private static string IssueFile { get; set; }

        private static string IssueBody { get; set; }

        public static string IssueTitle { get; private set; }
    }
}