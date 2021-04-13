using OpenQA.Selenium;

namespace OpenITDemo.Tests.Pages
{
	public class TweetControl : BaseControl
	{
		private IWebElement ContentSpan => Element.FindElement(By.CssSelector("[lang] > span"));

		public TweetControl(IWebElement element)
			: base(element)
		{
		}

		public Tweet GetTweet() => new Tweet { Message = ContentSpan.Text };
	}
}
