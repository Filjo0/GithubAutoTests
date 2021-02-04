using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GithubAutomation.Selenium
{
    public static class Driver
    {
        //change to your username and to your password
        public const string Username = "?";
        public const string Password = "?";
        public static IWebDriver Instance { get; private set; }

        public static string BaseAddress => "https://github.com/";

        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) (timeSpan.TotalSeconds * 1000));
        }
    }
}