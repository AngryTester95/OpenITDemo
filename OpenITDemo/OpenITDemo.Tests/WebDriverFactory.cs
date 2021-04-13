using FluentAssertions.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace OpenITDemo.Tests
{
	public class WebDriverFactory
	{
		public IWebDriver GetDriver(Browser browser)
		{
			IWebDriver driver = browser switch
			{
				Browser.Firefox => new FirefoxDriver(new FirefoxOptions { PageLoadStrategy = PageLoadStrategy.Normal }),
				Browser.InternetExplorer => new InternetExplorerDriver(new InternetExplorerOptions { PageLoadStrategy = PageLoadStrategy.Normal }),
				Browser.Chrome => new ChromeDriver(new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Normal }),
				_ => throw new NotImplementedException(),
			};

			driver.Manage().Timeouts().ImplicitWait = 2.Seconds();
			driver.Manage().Timeouts().PageLoad = 60.Seconds();
			driver.Manage().Window.Maximize();

			return driver;
		}
	}
}
