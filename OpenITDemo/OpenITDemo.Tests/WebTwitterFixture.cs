using FluentAssertions;
using NUnit.Framework;
using OpenITDemo.Domain;
using OpenITDemo.Web;
using OpenITDemo.Web.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace OpenITDemo.Tests
{
	[TestFixture]
	public class WebTwitterFixture
	{
		private IWebDriver driver;

		[SetUp]
		public void BeforeTest()
		{
			driver = new ChromeDriver();

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
			driver.Manage().Window.Maximize();

			driver.Url = "https://www.twitter.com";
		}

		[Test]
		public void UserShouldBeLoggedOn()
		{
			var page = new TwitterLogInWebPage(driver);
			page.LogIn(Users.OpenITDemoUser);

			var actualLoggedOnUser = new TwitterAccountWebPage(driver)
				.WaitForPageLoad()
				.Me;

			actualLoggedOnUser.Should().BeEquivalentTo(Users.OpenITDemoUser.Login);
		}

		[Test]
		public void TweetShouldBeCreated()
		{
			var tweet = new Tweet { Message = $"Hello, World{new Random().Next(100_000)}!" };

			var page = new TwitterLogInWebPage(driver);
			page.LogIn(Users.OpenITDemoUser);

			var accountPage = new TwitterAccountWebPage(driver)
				.WaitForPageLoad();

			accountPage.Tweet(tweet);
			accountPage.WaitForPageLoad().MyTweets.Should().Contain(tweet);
		}

		[TearDown]
		public void AfterTest()
		{
			driver?.Quit();
		}
	}
}
