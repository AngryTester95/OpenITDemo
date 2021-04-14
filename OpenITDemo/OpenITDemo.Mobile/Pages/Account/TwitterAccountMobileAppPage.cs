using OpenITDemo.Domain;
using OpenITDemo.Mobile.Controls;
using OpenITDemo.Mobile.Extensions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using System.Linq;

namespace OpenITDemo.Mobile.Pages
{
	public class TwitterAccountMobileAppPage : BaseMobilePage<TwitterAccountMobileAppPage>, ITwitterAccountPage
	{
		private AppiumWebElement TweetButton => Driver.FindElementById("com.twitter.android:id/composer_write");

		private AppiumWebElement Menu => Driver.FindElementByXPath(".//*[@resource-id='com.twitter.android:id/toolbar']/android.widget.ImageButton");

		private AppiumWebElement LoginElement => Driver.FindElementById("com.twitter.android:id/username");

		private IEnumerable<TweetMobileControl> TweetControls => Driver.FindElementsById("com.twitter.android:id/row").Select(el => new TweetMobileControl(el));

		public Login Me
		{
			get
			{
				Menu.Click();

				var value = LoginElement.Text.Trim('@');
				(Driver as AndroidDriver<AppiumWebElement>)?.PressKeyCode(AndroidKeyCode.Back);

				return new Login(value);
			}
		}

		public List<Tweet> MyTweets => TweetControls.Select(control => control.Extract()).ToList();

		public TwitterAccountMobileAppPage(AppiumDriver<AppiumWebElement> driver)
			: base(driver)
		{
		}

		public void Tweet(Tweet tweet)
		{
			TweetButton.Click();

			new CreateTweetMobileAppPage(Driver)
				.WaitForPageLoad()
				.CreateTweet(tweet);
		}

		public override TwitterAccountMobileAppPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => TweetButton.Displayed && Menu.Displayed);

			return this;
		}
	}
}
