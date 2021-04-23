using OpenQA.Selenium.Appium.Windows;

namespace OpenITDemo.Desktop.Controls
{
    public abstract class BaseDesktopControl
    {
        protected WindowsElement Element { get; }

        protected BaseDesktopControl(WindowsElement element)
        {
            Element = element;
        }
    }
}
