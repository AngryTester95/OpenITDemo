using FluentAssertions;
using NUnit.Framework;
using OpenITDemo.Desktop.Pages;
using OpenITDemo.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenITDemo.Tests
{
    [TestFixture]
    public class DesktopTwitterFixture
    {
        private WindowsDriver<WindowsElement> driver;

        [SetUp]
        public void BeforeTest()
        {
            var ops = new AppiumOptions();
            ops.AddAdditionalCapability("app", "Root");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4724"), ops);

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
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4724"), ops);
            //System.Xml.Linq.XDocument.Parse(driver.PageSource).Save("test3.xml", System.Xml.Linq.SaveOptions.None);
        }

        [Test]
        public void UserShouldBeLoggedOn()
        {
            var page = new TwitterLoginDesktopPage(driver);
            page.LogIn(Users.OpenITDemoUser);

            var actualLoggedOnUser = new TwitterAccountDesktopPage(driver)
                .WaitForPageLoad()
                .Me;

            actualLoggedOnUser.Should().BeEquivalentTo(Users.OpenITDemoUser.Login);
        }

        [Test]
        public void TweetShouldBeCreated()
        {
            var tweet = new Tweet { Message = $"Hello, World{new Random().Next(100_000)}!" };

            var page = new TwitterLoginDesktopPage(driver);
            page.LogIn(Users.OpenITDemoUser);

            var accountPage = new TwitterAccountDesktopPage(driver)
                .WaitForPageLoad();

            accountPage.Tweet(tweet);
            accountPage.WaitForPageLoad().MyTweets.Should().Contain(tweet);
        }

        [TearDown]
        public void AfterTest()
        {
            driver?.CloseApp();
        }
    }
}
