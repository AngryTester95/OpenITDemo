using OpenQA.Selenium;

namespace OpenITDemo.Tests.Pages
{
	public abstract class BasePage<TPage>
		where TPage : BasePage<TPage>
	{
		protected IWebDriver Driver { get; }

		protected BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public abstract TPage WaitForPageLoaded();
	}
}
