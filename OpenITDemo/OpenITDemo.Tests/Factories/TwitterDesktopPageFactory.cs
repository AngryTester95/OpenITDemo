using OpenITDemo.Desktop.Pages;
using OpenITDemo.Domain;
using OpenQA.Selenium.Appium.Windows;

namespace OpenITDemo.Tests
{
	public class TwitterDesktopPageFactory : BaseTwitterPageFactory
	{
		public override WindowsDriver<WindowsElement> Driver { get; }

		public TwitterDesktopPageFactory(WindowsDriver<WindowsElement> driver)
		{
			Driver = driver;
		}

		public override ITwitterAccountPage GetTwitterAccountPage()
		{
			return new TwitterAccountDesktopPage(Driver);
		}

		public override ITwitterLoginPage GetTwitterLoginPage()
		{
			return new TwitterLoginDesktopPage(Driver);
		}
	}
}
