using OpenITDemo.Domain;
using OpenITDemo.Web.Controls;
using OpenITDemo.Web.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OpenITDemo.Web.Pages
{
	public class TwitterAccountWebPage : BaseWebPage<TwitterAccountWebPage>, ITwitterAccountPage
	{
		#region Controls...

		private CreateTweetWebDialog CreateTweetWebDialog => new(Driver.FindElement(By.CssSelector("[role='dialog']")));

		private IWebElement TweetButton => Driver.FindElement(By.CssSelector("[data-testid='SideNav_NewTweet_Button']"));

		private IWebElement LogInSpan => Driver.FindElement(By.CssSelector("[data-testid='SideNav_AccountSwitcher_Button'] [dir='ltr'] > span"));

		private IEnumerable<TweetWebControl> TweetControls => Driver.FindElements(By.CssSelector("[data-testid='tweet']")).Select(el => new TweetWebControl(el));

		#endregion

		public Login Me => new(LogInSpan.Text.Trim('@'));

		public List<Tweet> MyTweets => TweetControls.Select(control => control.Extract()).ToList();

		public TwitterAccountWebPage(IWebDriver driver)
			: base(driver)
		{
		}

		public void Tweet(Tweet tweet)
		{
			TweetButton.Click();
			CreateTweetWebDialog.CreateTweet(tweet);

			Thread.Sleep(TimeSpan.FromSeconds(1));
		}

		public override TwitterAccountWebPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => TweetButton.Displayed);

			return this;
		}
	}
}
