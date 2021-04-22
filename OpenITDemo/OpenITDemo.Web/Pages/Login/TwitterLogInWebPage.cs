using OpenITDemo.Domain;
using OpenITDemo.Web.Extensions;
using OpenQA.Selenium;

namespace OpenITDemo.Web
{
	public class TwitterLogInWebPage : BaseWebPage<TwitterLogInWebPage>, ITwitterLoginPage
	{
		private const string Url = "https://www.twitter.com";

		private IWebElement LogInButton => Driver.FindElement(By.CssSelector("[data-testid='loginButton']"));

		public TwitterLogInWebPage(IWebDriver driver)
			: base(driver)
		{
			Driver.Url = Url;
		}

		public void LogIn(User user)
		{
			LogInButton.Click();

			new TwitterLogInFormWebPage(Driver)
				.WaitForPageLoad()
				.LogIn(user);
		}

		public override TwitterLogInWebPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => LogInButton.Displayed);

			return this;
		}
	}
}
