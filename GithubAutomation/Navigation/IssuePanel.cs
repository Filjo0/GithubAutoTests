using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Navigation
{
    public class IssuePanel
    {
        public class AddIssue
        {
            static IWebElement newIssueButton = Driver.Instance.FindElement(By.CssSelector("a.btn-primary.btn"));

            public static string GetText()
            {
                return newIssueButton.Text;
            }

            public static void Select()
            {
                newIssueButton.Click();
            }
        }
    }
}