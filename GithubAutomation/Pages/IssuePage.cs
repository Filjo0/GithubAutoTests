using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubTests.Smoke_Tests
{
    public class IssuePage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.CssSelector(""));
                return title != null ? title.Text : string.Empty;
            }
        }

        public static void GoToListOfIssues()
        {
        }

        public static bool IsAt()
        {
            return true;
        }

        public static void CreateIssue()
        {
        }
    }
}