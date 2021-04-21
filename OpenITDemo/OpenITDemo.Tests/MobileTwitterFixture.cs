using FluentAssertions;
using NUnit.Framework;
using OpenITDemo.Domain;
using OpenITDemo.Mobile.Extensions;
using OpenITDemo.Mobile.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.IO;

namespace OpenITDemo.Tests
{
	[TestFixture]
	public class MobileTwitterFixture
	{
		private const string appId = "com.twitter.android";

		private readonly Uri hub = new Uri("http://127.0.0.1:4723/wd/hub");

		private AndroidDriver<AppiumWebElement> driver;

		[SetUp]
		public void Initialize()
		{
			var options = new AppiumOptions();

			AddDevice(options);
			AddTwitter(options);

			driver = new AndroidDriver<AppiumWebElement>(hub, options);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[Test]
		public void UserShouldBeLoggedOn()
		{
			var page = new TwitterLogInMobileAppPage(driver);
			page.LogIn(Users.OpenITDemoUser);

			var actualLoggedOnUser = new TwitterAccountMobileAppPage(driver)
				.WaitForPageLoad()
				.Me;

			actualLoggedOnUser.Should().BeEquivalentTo(Users.OpenITDemoUser.Login);
		}

		[Test]
		public void TweetShouldBeCreated()
		{
			var tweet = new Tweet { Message = $"Hello, World{new Random().Next(100_000)}!" };

			var page = new TwitterLogInMobileAppPage(driver);
			page.LogIn(Users.OpenITDemoUser);

			var accountPage = new TwitterAccountMobileAppPage(driver)
				.WaitForPageLoad();

			accountPage.Tweet(tweet);
			driver.PullDown();

			accountPage.WaitForPageLoad().MyTweets
				.Should().Contain(tweet);
		}

		[TearDown]
		public void TearDown()
		{
			driver?.CloseApp();

			if (driver.IsAppInstalled(appId))
			{
				driver.RemoveApp(appId);
			}
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
