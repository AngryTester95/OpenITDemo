using OpenITDemo.Domain;
using OpenQA.Selenium.Appium;

namespace OpenITDemo.Mobile.Controls
{
	public class TweetMobileControl : BaseMobileControl
	{
		public Tweet Extract() => TweetParser.ParseTweet(Element.GetAttribute("content-desc"));

		public TweetMobileControl(AppiumWebElement element)
			: base(element)
		{
		}
	}
}
