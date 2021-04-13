using OpenQA.Selenium;

namespace OpenITDemo.Tests.Pages
{
	public abstract class BaseControl
	{
		protected IWebElement Element { get; }

		protected BaseControl(IWebElement element)
		{
			Element = element;
		}
	}
}
