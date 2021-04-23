using OpenITDemo.Domain;
using OpenQA.Selenium;

namespace OpenITDemo.Tests
{
	public abstract class BaseTwitterPageFactory
	{
		public abstract IWebDriver Driver { get; }

		public abstract ITwitterLoginPage GetTwitterLoginPage();

		public abstract ITwitterAccountPage GetTwitterAccountPage();
	}
}
