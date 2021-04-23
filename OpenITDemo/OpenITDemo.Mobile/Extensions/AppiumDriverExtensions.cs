using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;

namespace OpenITDemo.Mobile.Extensions
{
	public static class AppiumDriverExtensions
	{
		public static void PullDown(this AppiumDriver<AppiumWebElement> driver)
		{
			var touch = new TouchAction(driver);

			touch.Press(500, 1000)
				.Wait(500)
				.MoveTo(500, 1500)
				.Release()
				.Perform();
		}
	}
}
