using GithubAutomation.Pages;

namespace GithubAutomation.Workflows
{
    public static class RepoCreator
    {
        public static void CreateRepo()
        {
            RepoTitle = "TestRepo";
            RepoDescription = "Hi, this is the description.";
            IsPrivate = true;


            NewRepoPage.GoTo();
            NewRepoPage
                .CreateRepo(RepoTitle)
                .WithDescription(RepoDescription)
                .IsPrivate(IsPrivate)
                .Publish();
        }

        private static bool IsPrivate { get; set; }

        private static string RepoDescription { get; set; }

        private static string RepoTitle { get; set; }

        public static void Initialize()
        {
            RepoTitle = null;
            RepoDescription = null;
        }

        public static void CleanUp()
        {
            if (CreatedRepo)
            {
                DeleteRepo();
            }
        }

        private static bool CreatedRepo => !string.IsNullOrEmpty(RepoTitle);

        private static void DeleteRepo()
        {
            RepoPage.GoToRepoPage(RepoTitle);
            RepoPage.DeleteRepo(RepoTitle);
            Initialize();
        }
    }
}