using GithubAutomation.Navigation;

namespace GithubAutomation.Pages
{
    public static class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                NavigationPanel.UserImage.OpenDropMenu();
                var signedInAs = NavigationPanel.UserImage.FindElements();
                return signedInAs.Count > 0 && signedInAs[0].Text.Contains("Signed in as ");
            }
        }
    }
}