using FluentAssertions.Extensions;
using OpenITDemo.Tests.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenITDemo.Tests.Pages
{
	public class TwitterHomePage : BasePage<TwitterHomePage>
	{
		private IWebElement TweetButton => Driver.FindElement(By.CssSelector("[data-testid='SideNav_NewTweet_Button']"));

		private IEnumerable<TweetControl> TweetControls => Driver.FindElements(By.CssSelector("[data-testid='tweet']")).Select(el => new TweetControl(el));

		public TwitterHomePage(IWebDriver driver)
			: base(driver)
		{
		}

		public TwitterHomePage Tweet(Tweet tweet)
		{
			TweetButton.Click();
			return new TweetModalDialog(Driver).Tweet(tweet);
		}

		public List<Tweet> GetMyTweets()
		{
			return TweetControls
				.Select(control => control.GetTweet())
				.ToList();
		}

		public override TwitterHomePage WaitForPageLoaded()
		{
			Driver.Wait(10.Seconds()).Until(d => TweetButton.Displayed);
			return this;
		}
	}
}
