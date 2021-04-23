using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenITDemo.Web.Extensions
{
	public static class IWebDriverExtensions
	{
		public static WebDriverWait Wait(this IWebDriver driver, TimeSpan timeout, TimeSpan interval) => new(driver, timeout) { PollingInterval = interval };

		public static WebDriverWait Wait(this IWebDriver driver, TimeSpan timeout) => Wait(driver, timeout, TimeSpan.FromSeconds(0.5));
	}
}
