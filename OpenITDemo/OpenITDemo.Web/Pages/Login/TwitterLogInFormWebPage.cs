using OpenITDemo.Domain;
using OpenITDemo.Web.Extensions;
using OpenQA.Selenium;

namespace OpenITDemo.Web
{
	public class TwitterLogInFormWebPage : BaseWebPage<TwitterLogInFormWebPage>
	{
		#region Controls...

		private IWebElement LoginInput => Driver.FindElement(By.Name("session[username_or_email]"));

		private IWebElement PasswordInput => Driver.FindElement(By.Name("session[password]"));

		private IWebElement SubmitButton => Driver.FindElement(By.CssSelector("[data-testid='LoginForm_Login_Button']"));

		#endregion

		public TwitterLogInFormWebPage(IWebDriver driver)
			: base(driver)
		{
		}

		public void LogIn(User user)
		{
			LoginInput.SendKeys(user.Login.Value);
			PasswordInput.SendKeys(user.Password);

			SubmitButton.Click();
		}

		public override TwitterLogInFormWebPage WaitForPageLoad()
		{
			Driver
				.Wait(Timeouts.Wait)
				.Until(driver => LoginInput.Displayed && PasswordInput.Displayed);

			return this;
		}
	}
}
