using OpenITDemo.Domain;
using OpenITDemo.Mobile.Extensions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace OpenITDemo.Mobile.Pages
{
	public class TwitterLogInMobileAppPage : BaseMobilePage<TwitterLogInMobileAppPage>, ITwitterLoginPage
	{
		private AppiumWebElement LogInButton => Driver.FindElementById("com.twitter.android:id/detail_text");

		public TwitterLogInMobileAppPage(AppiumDriver<AppiumWebElement> driver)
			: base(driver)
		{
		}

		public void LogIn(User user)
		{
			(int offsetX, int offsetY) = GetLogInButtonOffset();

			new Actions(Driver)
				.MoveToElement(LogInButton, offsetX, offsetY)
				.Click()
				.Build()
				.Perform();

			new TwitterLogInFormMobileAppPage(Driver)
				.WaitForPageLoad()
				.LogIn(user);
		}

		public override TwitterLogInMobileAppPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => LogInButton.Displayed);

			return this;
		}

		private (int offsetX, int offsetY) GetLogInButtonOffset()
		{
			var size = LogInButton.Size;

			return ((int)(size.Width * 0.9), (int)(size.Height * 0.75));
		}
	}
}
