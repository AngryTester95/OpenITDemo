using OpenITDemo.Desktop.Extensions;
using OpenITDemo.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Linq;

namespace OpenITDemo.Desktop.Pages
{
    public class TwitterLoginDesktopPage : BaseDesktopPage<TwitterLoginDesktopPage>, ITwitterLoginPage
    {
        private WindowsElement LoginInput => Driver.FindElementsByName("Phone, email, or username")
            ?.Skip(1).FirstOrDefault() ?? throw new NoSuchElementException(nameof(LoginInput));

        private WindowsElement PasswordInput => Driver.FindElementsByName("Password")
            ?.Skip(1).FirstOrDefault() ?? throw new NoSuchElementException(nameof(PasswordInput));

        private WindowsElement SubmitButton => Driver.FindElementsByName("Log in")
            ?.Skip(1).FirstOrDefault() ?? throw new NoSuchElementException(nameof(SubmitButton));

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
