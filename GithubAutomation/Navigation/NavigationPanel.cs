using System.Collections.ObjectModel;
using GithubAutomation.Selenium;
using OpenQA.Selenium;

namespace GithubAutomation.Navigation
{
    public class NavigationPanel
    {
        public class AddNew
        {
            public static void Select()
            {
                var addButton = Driver.Instance.FindElement(By.CssSelector("summary > svg.octicon-plus"));
                addButton.Click();
            }

            public class Repos
            {
                public static void Select()
                {
                    var addNew = Driver.Instance.FindElement(By.LinkText("New repository"));
                    addNew.Click();
                }
            }
        }

        public class UserImage
        {
            public static void Select()
            {
                var avatar = Driver.Instance.FindElement(By.CssSelector("summary > img.avatar"));
                avatar.Click();
            }

            public static ReadOnlyCollection<IWebElement> FindElements()
            {
                return Driver.Instance.FindElements(By.ClassName("user-profile-link"));
            }
        }
    }
}