using OpenITDemo.Domain;
using OpenQA.Selenium.Appium;

namespace OpenITDemo.Mobile.Controls
{
	public class TweetMobileControl : BaseMobileControl
	{
		private AppiumWebElement Content => Element.FindElementById("com.twitter.android:id/tweet_content_text");

		public Tweet Extract() => new() { Message = Content.Text };

		public TweetMobileControl(AppiumWebElement element)
			: base(element)
		{
		}
	}
}
