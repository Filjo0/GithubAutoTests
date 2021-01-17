using System;
using GithubAutomation;
using GithubAutomation.Pages;
using GithubAutomation.Selenium;
using GithubTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GithubTests.Smoke_Tests
{
    [TestFixture]
    public class NewRepoTests : GithubTest
    {
        [Test]
        public void Can_Create_A_Repo()
        {
            NewRepoPage.GoTo();
            NewRepoPage
                .CreateRepo("TestRepo")
                .WithDescription("Hi, this is the description.")
                .IsPrivate(true)
                .Publish();

            Assert.AreEqual(RepoPage.Title, "TestRepo", "Title did not match new repo");
        }

        [Test]
        public void Can_Go_To_Repos_Page()
        {
            RepoPage.GoToListOfRepos();
            Assert.IsTrue(RepoPage.IsAtListOfReposPage, "Failed to open Repos page");
        }

        [Test]
        public void User_Have_Repos()
        {
            RepoPage.GoToListOfRepos();
            Assert.That(RepoPage.HaveRepos, "No repos found!");
        }

        [Test]
        public void Can_Open_First_Repo_Page()
        {
            RepoPage.GoToListOfRepos();
            if (RepoPage.HaveRepos())
            {
                RepoPage.GoToFirstRepoPage();
            }

            Assert.That(RepoPage.IsAtFirstRepoPage, "Cannot open this page!");
        }

        [Test]
        public void Can_Open_Certain_Repo_Page()
        {
            RepoPage.GoToListOfRepos();
            if (RepoPage.HaveRepos())
            {
                RepoPage.GoToRepoPage("TestRepo");
            }

            Assert.That(RepoPage.Title.Equals("TestRepo"), "Cannot open this page!");
        }

        [Test]
        public void Can_Delete_Repo_Page()
        {
            RepoPage.GoToListOfRepos();
            RepoPage.GoToRepoPage("TestRepo");
            RepoPage.DeleteRepo();

            Assert.That(RepoPage.DeletedMessage.Contains("was successfully deleted."),
                "Your repository was not deleted");
        }
    }
}