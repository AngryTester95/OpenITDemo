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
		public Tweet Tweet { get; private set; }

		public TweetDesktopControl(WindowsElement element)
			: base(element)
		{
			var tweetTextElement = element.FindElementByXPath("/Group/Group/Group/Group/Text");

			Tweet = new Tweet
			{
				Message = tweetTextElement.Text,
			};
		}
	}
}
