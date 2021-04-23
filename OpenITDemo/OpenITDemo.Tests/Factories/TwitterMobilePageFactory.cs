using OpenITDemo.Domain;
using OpenITDemo.Mobile.Pages;
using OpenQA.Selenium.Appium;

namespace OpenITDemo.Tests
{
	public class TwitterMobilePageFactory : BaseTwitterPageFactory
	{
		public override AppiumDriver<AppiumWebElement> Driver { get; }

		public TwitterMobilePageFactory(AppiumDriver<AppiumWebElement> driver)
		{
			Driver = driver;
		}

		public override ITwitterAccountPage GetTwitterAccountPage()
		{
			return new TwitterAccountMobileAppPage(Driver);
		}

		public override ITwitterLoginPage GetTwitterLoginPage()
		{
			return new TwitterLogInMobileAppPage(Driver);
		}
	}
}
