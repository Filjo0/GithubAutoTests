using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GithubAutomation.Navigation;
using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Pages
{
    public static class RepoPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.CssSelector("a[data-pjax='#js-repo-pjax-container']"));
                return title != null ? title.Text : string.Empty;
            }
        }

        private static IWebElement FindDisplayed(IEnumerable<IWebElement> elements)
        {
            return elements.FirstOrDefault(element => element.Displayed);
        }

        public static string DeletedMessage
        {
            get
            {
                var message = Driver.Instance.FindElement(By.CssSelector("div.px-2.container-lg"));
                return message != null ? message.Text : string.Empty;
            }
        }

        public static void GoToListOfRepos()
        {
            NavigationPanel.UserImage.Select();

            var goToReposPage = Driver.Instance.FindElement(By.LinkText("Your repositories"));
            goToReposPage.Click();
        }

        public static bool IsAt
        {
            get
            {
                var isRepoPage = Driver.Instance.FindElement(By.CssSelector("a.UnderlineNav-item.selected"));
                return Regex.Replace(isRepoPage.Text, @"\d+", "").Contains("Repositories");
            }
        }

        public static void OpenRepoPage(string title)
        {
            var repoPage = Driver.Instance.FindElement(By.LinkText(title));
            repoPage.Click();
        }

        public static void DeleteRepo()
        {
            RepoPanel.Settings.Select();

            var deleteButton = Driver.Instance.FindElements(By.CssSelector(
                "summary.btn.btn-danger.boxed-action.float-md-right.float-none.ml-0.ml-md-3.mt-md-0.mt-2"));
            foreach (var button in deleteButton)
            {
                if (button.Text == "Delete this repository")
                {
                    button.Click();
                }
            }

            var confirmation =
                FindDisplayed(Driver.Instance.FindElements(By.CssSelector("input.input-block.form-control")));

            var textToConfirm = Driver.Instance
                .FindElements(By.CssSelector("div.overflow-auto.Box-body p > strong"));
            foreach (var lineFromText in textToConfirm)
            {
                if (!lineFromText.Text.Contains("/")) continue;
                confirmation.SendKeys(lineFromText.Text);
                break;
            }

            var confirmationButton =
                FindDisplayed(Driver.Instance.FindElements(By.CssSelector("button.btn.btn-block.btn-danger")));
            confirmationButton.Click();
        }
    }
}