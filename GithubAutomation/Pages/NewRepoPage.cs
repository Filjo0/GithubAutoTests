using System;
using GithubAutomation.Navigation;
using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Pages
{
    public static class NewRepoPage
    {
        public static void GoTo()
        {
            NavigationPanel.AddNew.Select();
            NavigationPanel.AddNew.Repos.Select();
        }

        public static CreatRepoCommand CreateRepo(string title)
        {
            return new CreatRepoCommand(title);
        }
    }

    public class CreatRepoCommand
    {
        private readonly string _title;
        private string _description;
        private bool _isPrivate;

        public CreatRepoCommand(string title)
        {
            _title = title;
        }

        public CreatRepoCommand WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CreatRepoCommand IsPrivate(bool isPrivate)
        {
            _isPrivate = isPrivate;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("repository_name")).SendKeys(_title);
            Driver.Instance.FindElement(By.Id("repository_description")).SendKeys(_description);
            if (_isPrivate)
            {
                Driver.Instance.FindElement(By.Id("repository_visibility_private")).Click();
            }

            Driver.Wait(TimeSpan.FromSeconds(1));

            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-primary.first-in-line")).Click();
        }

        public static void UploadToNewRepo()
        {
            Driver.Instance.FindElement(By.LinkText(null));
        }
    }
}