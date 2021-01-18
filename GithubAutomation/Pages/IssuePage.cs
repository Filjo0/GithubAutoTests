using System;
using System.Linq;
using GithubAutomation.Navigation;
using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Pages
{
    public static class IssuePage
    {
        private static int _lastCount;

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.CssSelector("h1.break-word.f1"));
                return title != null ? title.Text : string.Empty;
            }
        }

        public static int PreviousIssueCount => _lastCount;

        public static int CurrentIssueCount => GetIssueCount();

        public static void GoToListOfIssues()
        {
            RepoPanel.Issues.Select();
        }

        public static bool IsAt()
        {
            return IssuePanel.AddIssue.GetText().Contains("New issue");
        }

        public static void OpenNewIssueWindow()
        {
            IssuePanel.AddIssue.Select();
        }

        public static CreatIssueCommand CreateIssue(string title)
        {
            return new CreatIssueCommand(title);
        }

        public static void CountIssues()
        {
            _lastCount = GetIssueCount();
        }

        private static int GetIssueCount()
        {
            var number = 0;
            var countIssues =
                Driver.Instance.FindElement(By.CssSelector("[data-tab-item='i1issues-tab'] span.Counter"));
            if (countIssues.Displayed)
            {
                number = Convert.ToInt32(countIssues.Text);
            }

            Console.WriteLine(number);
            return number;
        }

        public static bool? DoesIssueExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void DeleteIssue(string title)
        {
            var issuesWithTitle = Driver.Instance.FindElements(By.LinkText(title));
            if (issuesWithTitle.Count > 0)
            {
                issuesWithTitle[0].Click();
            }

            var buttons = Driver.Instance.FindElements(By.CssSelector("summary span strong"));
            foreach (var button in buttons)
            {
                if (button.Text.Contains("Delete"))
                {
                    button.Click();
                }
            }

            var submitDeleteButton =
                Driver.Instance.FindElement(By.CssSelector("button[name='verify_delete']"));
            if (submitDeleteButton.Displayed)
            {
                submitDeleteButton.Click();
            }
        }
    }

    public class CreatIssueCommand
    {
        private readonly string _title;
        private string _issueBody;
        private string _filepath;

        public CreatIssueCommand(string title)
        {
            _title = title;
        }


        public CreatIssueCommand WithBody(string issueBody)
        {
            _issueBody = issueBody;
            return this;
        }

        public CreatIssueCommand UploadFile(string filepath)
        {
            _filepath = filepath;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("issue_title")).SendKeys(_title);
            Driver.Instance.FindElement(By.Id("issue_body")).SendKeys(_issueBody);
            if (_filepath.Length > 0)
            {
                Driver.Instance.FindElement(By.Id("fc-issue_body")).SendKeys(_filepath);
            }

            Driver.Wait(TimeSpan.FromSeconds(5));

            Driver.Instance.FindElement(By.CssSelector(".flex-items-center button.btn-primary.btn")).Click();
        }
    }
}