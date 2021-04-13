using NUnit.Framework;
using OpenITDemo.Domain;
using OpenITDemo.Mobile.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenITDemo.Tests
{
	[TestFixture]
	public class MobileTwitterFixture
	{
		private AndroidDriver<AppiumWebElement> driver;

		private AppiumLocalService localService;

		[SetUp]
		public void Initialize()
		{
			var options = new AppiumOptions();
			options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "HUAWEI P30 lite");
			options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
			options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
			//options.AddAdditionalCapability(MobileCapabilityType.BrowserName, "chrome");
			options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\yanus\OneDrive\Desktop\twitter.apk");
			options.AddAdditionalCapability("appPackage", "com.twitter.android");
			options.AddAdditionalCapability("appActivity", "com.twitter.android.StartActivity");
			driver = new AndroidDriver<AppiumWebElement>(new Uri($"http://127.0.0.1:4723/wd/hub"), options);
		}

		[Test]
		public void M()
		{
			var page = new TwitterLogInMobileAppPage(driver);
			page.LogIn(new User { Login = new Login("demo_open"), Password = "zaq123ZAQ!@#" });
			new TwitterAccountMobileAppPage(driver).Tweet(new Tweet { Message = "Hello, Aleh!!!" });
			var t = new TwitterAccountMobileAppPage(driver).MyTweets;

			var me = new TwitterAccountMobileAppPage(driver).Me;
		}

		[TearDown]
		public void TearDown()
		{
			driver?.CloseApp();
			localService?.Dispose();
		}
	}
}
