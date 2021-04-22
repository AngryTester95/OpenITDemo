using FluentAssertions;
using OpenITDemo.Domain;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace OpenITDemo.Tests
{
	[Binding]
	public sealed class TwitterStepDefinitions
	{
		private static readonly string _pattern = @"{rand:(\d+)}";

		private readonly ScenarioContext _context;

		private IWebDriver driver;

		private ITwitterLoginPage loginPage;

		private ITwitterAccountPage accountPage;

		private  readonly Dictionary<string, IBasePage> pages;

		public TwitterStepDefinitions(ScenarioContext context)
		{
			_context = context;

			pages = new Dictionary<string, IBasePage>();
		}

		[Given(@"Open Twitter with (.*)")]
		public void GivenOpenTwitterWith(Device device)
		{
			var pageFactory = ResolvePageFactory(device);

			driver = pageFactory.Driver;
			pages["Login"] = loginPage = pageFactory.GetTwitterLoginPage();
			pages["Account"] = accountPage = pageFactory.GetTwitterAccountPage();
		}

		[When(@"I do Log In with (.*) user")]
		public void WhenIDoLogInWith(string userAlias)
		{
			loginPage.LogIn(Users.Get(userAlias));
		}

		[Then(@"(.*) page is loaded")]
		public void ThenPageIsLoaded(string pageName)
		{
			pages[pageName].WaitForPageLoad();
		}

		[Then(@"I logged in with (.*) user")]
		public void ThenILoggedInWith(string userAlias)
		{
			accountPage.Me.Should().BeEquivalentTo(Users.Get(userAlias).Login);
		}

		[When(@"I tweet (.*)")]
		public void WhenITweetHelloOpenITRand(string tweetText)
		{
			var tweet = new Tweet
			{
				Message = TransformTweetText(tweetText),
			};
			_context.Add("tweet", tweet);
			accountPage.Tweet(tweet);
		}

		[Then(@"My tweet is posted")]
		public void ThenMyTweetIsPosted()
		{
			var tweet = _context.Get<Tweet>("tweet");

			accountPage.WaitForPageLoad();

			accountPage.MyTweets
				.Should().Contain(tweet);
		}

		[AfterScenario]
		public void AfterScenario()
		{
			driver?.Quit();
		}

		private static BaseTwitterPageFactory ResolvePageFactory(Device device)
		{
			return device switch
			{
				Device.Android => new TwitterMobilePageFactory(DriverFactory.GetMobileDriver()),
				Device.Desktop => new TwitterDesktopPageFactory(DriverFactory.GetDesktopDriver()),
				Device.Browser => new TwitterWebPageFactory(DriverFactory.GetWebDriver()),
				_ => throw new NotSupportedException($"unknown '{device}' device.")
			};
		}

		private static string TransformTweetText(string tweetText)
		{
			var match = Regex.Match(tweetText, _pattern);
			var count = int.Parse(match.Groups[1].Value);

			return Regex.Replace(tweetText, _pattern, Generator.Get(count));
		}

		public enum Device
		{
			Browser,
			Android,
			Desktop
		}
	}
}
