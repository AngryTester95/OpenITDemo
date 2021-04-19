using OpenITDemo.Desktop.Extensions;
using OpenITDemo.Domain;
using OpenQA.Selenium.Appium.Windows;

namespace OpenITDemo.Desktop.Pages
{
    public class TwitterLoginDesktopPage : BaseDesktopPage<TwitterLoginDesktopPage>, ITwitterLoginPage
    {
        private WindowsElement LoginInput => Driver.FindElementsByName("Phone, email, or username")[1];

        private WindowsElement PasswordInput => Driver.FindElementsByName("Password")[1];

        private WindowsElement SubmitButton => Driver.FindElementsByName("Log in")[1];

        public TwitterLoginDesktopPage(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {
        }

        public void LogIn(User user)
        {
            LoginInput.Click();
            LoginInput.SendKeys(user.Login.Value);

            PasswordInput.Click();
            PasswordInput.SendKeys(user.Password);

            SubmitButton.Click();
        }

        public override TwitterLoginDesktopPage WaitForPageLoad()
        {
            Driver
                .Wait(Timeouts.Wait)
                .Until(driver => LoginInput.Displayed && PasswordInput.Displayed);

            return this;
        }
    }
}
