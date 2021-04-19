using OpenITDemo.Domain;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenITDemo.Desktop.Controls
{
	public class TweetDesktopControl : BaseDesktopControl
	{
		public Tweet Extract() => throw new NotImplementedException();

		public TweetDesktopControl(WindowsElement element)
			: base(element)
		{
		}
	}
}
