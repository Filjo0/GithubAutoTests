using System;
using GithubAutomation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GithubAutomation.Pages
{
    public static class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "login");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "login_field");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }

    public class LoginCommand
    {
        private readonly string _username;
        private string _password;

        public LoginCommand(string username)
        {
            _username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("login_field"));
            loginInput.SendKeys(_username);

            var passwordInput = Driver.Instance.FindElement(By.Id("password"));
            passwordInput.SendKeys(_password);

            var loginButton = Driver.Instance.FindElement(By.CssSelector("input.btn.btn-primary.btn-block"));
            loginButton.Click();
        }
    }
}