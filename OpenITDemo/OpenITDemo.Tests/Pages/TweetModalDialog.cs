using FluentAssertions.Extensions;
using OpenITDemo.Tests.Extensions;
using OpenQA.Selenium;

namespace OpenITDemo.Tests.Pages
{
	public class TweetModalDialog : BasePage<TweetModalDialog>
	{
		private IWebElement AreaModal => Driver.FindElement(By.CssSelector("[role='dialog']"));

		private IWebElement MessageTextArea => AreaModal.FindElement(By.CssSelector("[data-testid='tweetTextarea_0']"));

		private IWebElement TweetButton => AreaModal.FindElement(By.CssSelector("[data-testid='tweetButton']"));

		public TweetModalDialog(IWebDriver driver)
			: base(driver)
		{
		}

		public override TweetModalDialog WaitForPageLoaded()
		{
			Driver.Wait(10.Seconds()).Until(d => MessageTextArea.Displayed && TweetButton.Displayed);
			return this;
		}

		public TwitterHomePage Tweet(Tweet tweet)
		{
			MessageTextArea.SendKeys(tweet.Message);
			TweetButton.Click();

			var wait = Driver.Wait(2.Seconds());
			wait.Until(d =>
			{
				try
				{
					return !AreaModal.Displayed;
				}
				catch
				{
					return true;
				}
			});

			return new TwitterHomePage(Driver).WaitForPageLoaded();
		}
	}
}
