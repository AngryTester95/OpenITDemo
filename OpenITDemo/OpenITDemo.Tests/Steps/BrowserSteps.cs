using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OpenITDemo.Tests.Steps
{
	[Binding]
	public sealed class BrowserSteps
	{
		private readonly ScenarioContext scenarioContext;

		public BrowserSteps(ScenarioContext scenarioContext)
		{
			this.scenarioContext = scenarioContext;
		}

		[Given("I open a browser (.*)")]
		public void OpenBrowser(Browser browser)
		{
			scenarioContext["browser"] = new WebDriverFactory().GetDriver(browser);
		}

		[When("Navigate to (.*)")]
		public void NavigateTo(string url)
		{
			(scenarioContext["browser"] as IWebDriver).Url = url;
		}

		[AfterScenario]
		public void CloseBrowser()
		{
			(scenarioContext["browser"] as IWebDriver).Quit();
		}
	}
}
