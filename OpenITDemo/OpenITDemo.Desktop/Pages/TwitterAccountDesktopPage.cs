using OpenITDemo.Desktop.Controls;
using OpenITDemo.Desktop.Extensions;
using OpenITDemo.Domain;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenITDemo.Desktop.Pages
{
    public class TwitterAccountDesktopPage : BaseDesktopPage<TwitterAccountDesktopPage>, ITwitterAccountPage
    {
        private WindowsElement TweetButton => Driver.FindElementByName("Tweet");

        private IEnumerable<TweetDesktopControl> TweetControls => Driver.FindElementsById("com.twitter.android:id/row").Select(el => new TweetDesktopControl(el));

        public Login Me => throw new NotImplementedException();

        public List<Tweet> MyTweets => throw new NotImplementedException();

        public TwitterAccountDesktopPage(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {

        }

        public void Tweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public override TwitterAccountDesktopPage WaitForPageLoad()
        {
            Driver
                .Wait(Timeouts.Wait)
                .Until(driver => TweetButton.Displayed);

            return this;
        }
    }
}
