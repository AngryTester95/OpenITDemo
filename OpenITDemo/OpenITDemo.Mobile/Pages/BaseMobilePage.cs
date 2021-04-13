using OpenQA.Selenium.Appium;

namespace OpenITDemo.Mobile.Pages
{
	public abstract class BaseMobilePage<TMobileAppPage>
		where TMobileAppPage : BaseMobilePage<TMobileAppPage>
	{
		protected AppiumDriver<AppiumWebElement> Driver { get; }

		protected BaseMobilePage(AppiumDriver<AppiumWebElement> driver)
		{
			Driver = driver;
		}

		public abstract TMobileAppPage WaitForPageLoad();
	}
}
