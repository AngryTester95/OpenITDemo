using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenITDemo.Desktop.Extensions
{
	public static class WindowsDriverExtensions
	{
		public static WebDriverWait Wait(this IWebDriver driver, TimeSpan timeout, TimeSpan interval)
		{
			var wait = new WebDriverWait(driver, timeout) { PollingInterval = interval };
			wait.IgnoreExceptionTypes(typeof(WebDriverException));
			return wait;
		}

		public static WebDriverWait Wait(this IWebDriver driver, TimeSpan timeout) => Wait(driver, timeout, TimeSpan.FromSeconds(0.5));
	}
}
