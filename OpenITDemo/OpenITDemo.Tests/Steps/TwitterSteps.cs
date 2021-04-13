using FluentAssertions;
using OpenITDemo.Tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OpenITDemo.Tests.Steps
{
	[Binding]
	public class TwitterSteps
	{
		private readonly ScenarioContext scenarioContext;

		public TwitterSteps(ScenarioContext scenarioContext)
		{
			this.scenarioContext = scenarioContext;
		}

		[When("login with (.*) login and (.*) password")]
		public void LoginToTwitter(string login, string password)
		{
			var user = new TwitterUser { Login = login, Password = password };
			new TwitterLoginPage(scenarioContext["browser"] as IWebDriver).Login(user);
		}

		[When("create a tweet with (.*) content")]
		public void CreateTweet(string content)
		{
			var tweet = new Tweet { Message = content };
			new TwitterHomePage(scenarioContext["browser"] as IWebDriver).Tweet(tweet);
		}

		[Then("tweet with (.*) content should be created")]
		public void TweetShouldBeCreated(string content)
		{
			var tweet = new Tweet { Message = content };

			new TwitterHomePage(scenarioContext["browser"] as IWebDriver)
				.GetMyTweets()
				.Should()
				.Contain(tweet);
		}

		[Then("user should be logged on")]
		public void ShouldBeLoggedOn()
		{
			new TwitterHomePage(scenarioContext["browser"] as IWebDriver).WaitForPageLoaded();
		}
	}
}
