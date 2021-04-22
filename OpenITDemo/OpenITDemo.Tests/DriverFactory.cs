using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace OpenITDemo.Tests
{
	public static class DriverFactory
	{
		public static IWebDriver GetWebDriver()
		{
			var driver = new ChromeDriver();

			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
			driver.Manage().Window.Maximize();

			return driver;
		}

		public static WindowsDriver<WindowsElement> GetDesktopDriver()
		{
			var ops = new AppiumOptions();
			ops.AddAdditionalCapability("app", "Root");
			var driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), ops);

			driver.Keyboard.PressKey(Keys.Command + "s" + Keys.Command);
			Thread.Sleep(1000);
			driver.Keyboard.PressKey("Twitter");
			Thread.Sleep(1000);
			driver.Keyboard.PressKey(Keys.Enter);
			Thread.Sleep(1000);
			driver.Keyboard.PressKey(Keys.Escape);

			var twitterWindow = driver.FindElementByName("Twitter");
			var twitterHandle = int.Parse(twitterWindow.GetAttribute("NativeWindowHandle")).ToString("x");
			ops = new AppiumOptions();
			ops.AddAdditionalCapability("appTopLevelWindow", twitterHandle);

			return new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), ops);
		}

		public static AndroidDriver<AppiumWebElement> GetMobileDriver()
		{
			var hub = new Uri("http://127.0.0.1:4723/wd/hub");
			var options = new AppiumOptions();

			AddDevice(options);
			AddTwitter(options);

			return new AndroidDriver<AppiumWebElement>(hub, options);
		}

		private static AppiumOptions AddDevice(AppiumOptions options)
		{
			options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 3A 29");
			options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
			options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
			options.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5556");

			return options;
		}

		private static AppiumOptions AddTwitter(AppiumOptions options)
		{
			options.AddAdditionalCapability(MobileCapabilityType.App, Path.Combine(Directory.GetCurrentDirectory(), "twitter.apk"));
			options.AddAdditionalCapability("appPackage", "com.twitter.android");
			options.AddAdditionalCapability("appActivity", "com.twitter.android.StartActivity");

			return options;
		}
	}
}
