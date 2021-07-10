using System;
using System.Reflection;
using GithubAutomation.Pages;
using GithubAutomation.Selenium;
using GithubAutomation.Workflows;
using log4net;
using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace GithubTests.Utilities
{
    [TestFixture]
    public class BaseSetup
    {
        private static readonly ILog Log = LogManager.GetLogger
            (MethodBase.GetCurrentMethod().DeclaringType);

        // change to your username and to your password
        private const string Username = "?";
        private const string Password = "?";

        [SetUp]
        public void Initialize()
        {
            try
            {
                Driver.Initialize();
                XmlConfigurator.Configure();

                RepoCreator.Initialize();

                LoginPage.GoTo();
                LoginPage
                    .LoginAs(Username)
                    .WithPassword(Password)
                    .Login();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message + exception.StackTrace);

                throw;
            }
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Log.Error("Failed to test " + TestContext.CurrentContext.Test.Name);
                Driver.Close();
            }
            // Clean up data
            RepoCreator.CleanUp();
            Driver.Close();
        }
    }
}