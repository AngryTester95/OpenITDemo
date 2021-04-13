using OpenITDemo.Domain;
using OpenITDemo.Mobile.Extensions;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;

namespace OpenITDemo.Mobile.Pages
{
	public class CreateTweetMobileAppPage : BaseMobilePage<CreateTweetMobileAppPage>
	{
		private AppiumWebElement TweetTextArea => Driver.FindElementById("com.twitter.android:id/tweet_text");

		private AppiumWebElement TweetButton => Driver.FindElementById("com.twitter.android:id/button_tweet");

		public CreateTweetMobileAppPage(AppiumDriver<AppiumWebElement> driver)
			: base(driver)
		{
		}

		public void CreateTweet(Tweet tweet)
		{
			TweetTextArea.SendKeys(tweet.Message);
			TweetButton.Click();

			Thread.Sleep(TimeSpan.FromSeconds(3));
		}

		public override CreateTweetMobileAppPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => TweetTextArea.Displayed && TweetTextArea.Displayed);

			return this;
		}
	}
}
