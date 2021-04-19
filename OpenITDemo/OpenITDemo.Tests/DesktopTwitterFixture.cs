using NUnit.Framework;
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
        private readonly User user = new User { Login = new Login("demo_open"), Password = "zaq123ZAQ!@#" };

        [Test]
        public void Start()
        {
            var ops = new AppiumOptions();
            ops.AddAdditionalCapability("app", "Root");
            var desktop = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), ops);

            desktop.Keyboard.PressKey(Keys.Command + "s" + Keys.Command);
            Thread.Sleep(1000);
            desktop.Keyboard.PressKey("Twitter");
            Thread.Sleep(1000);
            desktop.Keyboard.PressKey(Keys.Enter);
            Thread.Sleep(1000);
            desktop.Keyboard.PressKey(Keys.Escape);

            var twitterWindow = desktop.FindElementByName("Twitter");
            var twitterHandle = int.Parse(twitterWindow.GetAttribute("NativeWindowHandle")).ToString("x");
            ops = new AppiumOptions();
            ops.AddAdditionalCapability("appTopLevelWindow", twitterHandle);
            var twitter = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), ops);

            var els = twitter.FindElementsByName("Phone, email, or username");
            els[1].Click();
            els[1].SendKeys(user.Login.Value);

            els = twitter.FindElementsByName("Password");
            els[1].Click();
            els[1].SendKeys(user.Password);

            els = twitter.FindElementsByName("Log in");
            els[1].Click();
        }
    }
}
