using OpenQA.Selenium.Appium;

namespace OpenITDemo.Mobile.Controls
{
	public abstract class BaseMobileControl
	{
		protected AppiumWebElement Element { get; }

		protected BaseMobileControl(AppiumWebElement element)
		{
			Element = element;
		}
	}
}
