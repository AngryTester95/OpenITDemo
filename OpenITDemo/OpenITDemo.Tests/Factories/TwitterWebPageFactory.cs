using OpenITDemo.Domain;
using OpenITDemo.Web;
using OpenITDemo.Web.Pages;
using OpenQA.Selenium;

namespace OpenITDemo.Tests
{
	public class TwitterWebPageFactory : BaseTwitterPageFactory
	{
		public override IWebDriver Driver { get; }

		public TwitterWebPageFactory(IWebDriver driver)
		{
			Driver = driver;
		}

		public override ITwitterAccountPage GetTwitterAccountPage()
		{
			return new TwitterAccountWebPage(Driver);
		}

		public override ITwitterLoginPage GetTwitterLoginPage()
		{
			return new TwitterLogInWebPage(Driver);
		}
	}
}
