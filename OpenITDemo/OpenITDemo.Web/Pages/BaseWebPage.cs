using OpenITDemo.Domain;
using OpenQA.Selenium;

namespace OpenITDemo.Web
{
	public abstract class BaseWebPage<TWebPage> : IBasePage
		where TWebPage : BaseWebPage<TWebPage>
	{
		protected IWebDriver Driver { get; }

		protected BaseWebPage(IWebDriver driver)
		{
			Driver = driver;
		}

		public abstract TWebPage WaitForPageLoad();

		IBasePage IBasePage.WaitForPageLoad()
		{
			return WaitForPageLoad();
		}
	}
}
