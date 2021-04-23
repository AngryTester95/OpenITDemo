using OpenITDemo.Domain;
using OpenQA.Selenium;

namespace OpenITDemo.Web.Controls
{
	public class TweetWebControl : BaseWebControl
	{
		private IWebElement Content => Element.FindElement(By.CssSelector("[lang] > span"));

		public TweetWebControl(IWebElement element)
			: base(element)
		{
		}

		public Tweet Extract()
		{
			return new Tweet { Message = Content.Text };
		}
	}
}
