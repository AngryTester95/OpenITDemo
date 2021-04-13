using FluentAssertions.Extensions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace OpenITDemo.Tests.Pages
{
	public class MobileTwitterLoginPage : BaseMobilePage<MobileTwitterLoginPage>
	{
		private AppiumWebElement LogInButton => Driver.FindElementById("com.twitter.android:id/sign_in_text");

		private AppiumWebElement LoginInput => Driver.FindElementById("com.twitter.android:id/login_identifier");

		private AppiumWebElement PasswordInput => Driver.FindElementById("com.twitter.android:id/login_password");

		private AppiumWebElement LoginFormButton => Driver.FindElementById("com.twitter.android:id/login_login");

		public MobileTwitterLoginPage(AppiumDriver<AppiumWebElement> driver)
			: base(driver)
		{
		}

		public void LogIn(TwitterUser user)
		{
			var (offsetX, offsetY) = GetLogInButtonOffset();

			(int x, int y) = (LogInButton.Location.X + offsetX, LogInButton.Location.Y + offsetY);

			new Actions(Driver)
				.MoveToElement(LogInButton, offsetX, offsetY)
				.Click()
				.Build()
				.Perform();

			Thread.Sleep(3.Seconds());

			LoginInput.SendKeys(user.Login);
			PasswordInput.SendKeys(user.Password);

			LoginFormButton.Click();
		}

		private (int offsetX, int offsetY) GetLogInButtonOffset()
		{
			var size = LogInButton.Size;

			return ((int)(size.Width * 0.9), (int)(size.Height * 0.75));
		}
	}
}
