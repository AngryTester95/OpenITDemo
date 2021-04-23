using OpenITDemo.Desktop.Controls;
using OpenITDemo.Desktop.Extensions;
using OpenITDemo.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenITDemo.Desktop.Pages
{
    public class TwitterAccountDesktopPage : BaseDesktopPage<TwitterAccountDesktopPage>, ITwitterAccountPage
    {
        private WindowsElement MainTweetButton => Driver.FindElementByName("Tweet");

        private IEnumerable<TweetDesktopControl> TweetControls => Driver.FindElementsByXPath("//Group[@LocalizedControlType='article']").Select(el => new TweetDesktopControl(el));

        private WindowsElement Menu => Driver.FindElementByName("Account menu");

        private WindowsElement LoginElement => Driver.FindElementByXPath("//*[@LocalizedControlType='dialog']//ListItem");

        private WindowsElement TweetInput => Driver.FindElementByName("Tweet text");
        private WindowsElement TweetButton => Driver.FindElementsByName("Tweet")
            ?.Skip(1).FirstOrDefault() ?? throw new NoSuchElementException(nameof(TweetButton));

        private WindowsElement TweetSentPopup => Driver.FindElementByName("Your Tweet was sent.");

        public Login Me
        {
            get
            {
                Menu.Click();

                Driver.Wait(Timeouts.Wait)
                    .Until(driver => LoginElement.Displayed);

                var value = LoginElement.Text?.Split('@').Skip(1).FirstOrDefault();
                LoginElement.SendKeys(Keys.Escape);

                return new Login(value);
            }
        }

        public List<Tweet> MyTweets => TweetControls.Select(control => control.Tweet).ToList();

        public TwitterAccountDesktopPage(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {
            
        }

        public void Tweet(Tweet tweet)
        {
            TweetInput.Click();
            TweetInput.SendKeys(tweet.Message);

            Driver.Wait(Timeouts.Wait)
                .Until(driver => TweetButton.Enabled);

            TweetButton.Click();

            Thread.Sleep(2000);

            Driver.Wait(Timeouts.Wait)
                .Until(driver => TweetButton.Displayed && !TweetButton.Enabled);
        }

        public override TwitterAccountDesktopPage WaitForPageLoad()
        {
            Driver
                .Wait(Timeouts.Wait)
                .Until(driver => MainTweetButton.Displayed);

            return this;
        }
    }
}
