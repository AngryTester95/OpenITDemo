using FluentAssertions.Extensions;
using OpenITDemo.Tests.Extensions;
using OpenQA.Selenium;

namespace OpenITDemo.Tests.Pages
{
	public class TwitterLoginPage : BasePage<TwitterLoginPage>
	{
		private IWebElement LoginButton => Driver.FindElement(By.CssSelector("[data-testid='loginButton']"));

		private IWebElement LoginInput => Driver.FindElement(By.Name("session[username_or_email]"));

		private IWebElement PasswordInput => Driver.FindElement(By.Name("session[password]"));

		private IWebElement LoginFormLoginButton => Driver.FindElement(By.CssSelector("[data-testid='LoginForm_Login_Button']"));

		public TwitterLoginPage(IWebDriver driver)
			: base(driver)
		{
		}

		public override TwitterLoginPage WaitForPageLoaded()
		{
			Driver.Wait(10.Seconds()).Until(d => LoginButton.Displayed);
			return this;
		}

		public void Login(TwitterUser user)
		{
			LoginButton.Click();
			WaitForLoginForm();

			LoginInput.SendKeys(user.Login);
			PasswordInput.SendKeys(user.Password);
			LoginFormLoginButton.Click();
		}

		private TwitterLoginPage WaitForLoginForm()
		{
			Driver.Wait(10.Seconds()).Until(d => LoginInput.Displayed && PasswordInput.Displayed);
			return this;
		}
	}
}
