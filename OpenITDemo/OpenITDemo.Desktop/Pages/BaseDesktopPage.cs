using OpenITDemo.Domain;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenITDemo.Desktop.Pages
{
    public abstract class BaseDesktopPage<TDesktopAppPage> : IBasePage
        where TDesktopAppPage : BaseDesktopPage<TDesktopAppPage>
    {
        protected WindowsDriver<WindowsElement> Driver;

        public BaseDesktopPage(WindowsDriver<WindowsElement> driver)
        {
            Driver = driver;
        }
        public abstract TDesktopAppPage WaitForPageLoad();

        IBasePage IBasePage.WaitForPageLoad()
        {
            return WaitForPageLoad();
        }
    }
}
