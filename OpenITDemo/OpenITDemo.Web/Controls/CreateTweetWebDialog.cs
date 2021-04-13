using OpenITDemo.Domain;
using OpenQA.Selenium;

namespace OpenITDemo.Web.Controls
{
	public class CreateTweetWebDialog : BaseWebControl
	{
		private IWebElement TweetTextArea => Element.FindElement(By.CssSelector("[data-tesid='tweetTextarea_0']"));

		private IWebElement TweetButton => Element.FindElement(By.CssSelector("[data-testid='tweetButton']"));

		public CreateTweetWebDialog(IWebElement element)
			: base(element)
		{
		}

		public void CreateTweet(Tweet tweet)
		{
			TweetTextArea.SendKeys(tweet.Message);
			TweetButton.Click();
		}
	}
}
