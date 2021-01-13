using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Navigation
{
    public class RepoPanel
    {
        public class Settings
        {
            public static void Select()
            {
                var settings = Driver.Instance.FindElement(By.LinkText("Settings"));
                settings.Click();
            }
        }

        public class Issues
        {
            public static void Select()
            {
                var issues = Driver.Instance.FindElement(By.LinkText("Issues"));
                issues.Click();
            }
        }
    }
}