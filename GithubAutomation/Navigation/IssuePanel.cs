using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Navigation
{
    public class IssuePanel
    {
        public class AddIssue
        {
            private static readonly IWebElement NewIssueButton = Driver.Instance.FindElement(By.CssSelector("a.btn-primary.btn"));

            public static string GetText()
            {
                return NewIssueButton.Text;
            }

            public static void Select()
            {
                NewIssueButton.Click();
            }
        }
    }
}