using System;
using System.IO;
using GithubAutomation.Navigation;
using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Pages
{
    public static class IssuePage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.CssSelector("h1.break-word.f1"));
                return title != null ? title.Text : string.Empty;
            }
        }

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