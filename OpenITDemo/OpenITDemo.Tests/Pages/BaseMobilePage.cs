using OpenQA.Selenium.Appium;

namespace OpenITDemo.Tests.Pages
{
	public abstract class BaseMobilePage<TPage> 
		where TPage : BaseMobilePage<TPage>
	{
		protected AppiumDriver<AppiumWebElement> Driver { get; }

		protected BaseMobilePage(AppiumDriver<AppiumWebElement> driver)
		{
			Driver = driver;
		}
	}
}
