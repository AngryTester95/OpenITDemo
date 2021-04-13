using OpenQA.Selenium;

namespace OpenITDemo.Web.Controls
{
	public abstract class BaseWebControl
	{
		protected IWebElement Element { get; }

		protected BaseWebControl(IWebElement element)
		{
			Element = element;
		}
	}
}
