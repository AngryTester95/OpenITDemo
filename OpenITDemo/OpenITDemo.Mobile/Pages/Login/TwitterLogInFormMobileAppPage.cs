using OpenITDemo.Domain;
using OpenITDemo.Mobile.Extensions;
using OpenQA.Selenium.Appium;

namespace OpenITDemo.Mobile.Pages
{
	public class TwitterLogInFormMobileAppPage : BaseMobilePage<TwitterLogInFormMobileAppPage>
	{
		private AppiumWebElement LoginInput => Driver.FindElementById("com.twitter.android:id/login_identifier");

		private AppiumWebElement PasswordInput => Driver.FindElementById("com.twitter.android:id/login_password");

		private AppiumWebElement SubmitButton => Driver.FindElementById("com.twitter.android:id/login_login");

		public TwitterLogInFormMobileAppPage(AppiumDriver<AppiumWebElement> driver)
			: base(driver)
		{
		}

		public void LogIn(User user)
		{
			LoginInput.SendKeys(user.Login.Value);
			PasswordInput.SendKeys(user.Password);

			SubmitButton.Click();
		}

		public override TwitterLogInFormMobileAppPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => LoginInput.Displayed && PasswordInput.Displayed);

			return this;
		}
	}
}
