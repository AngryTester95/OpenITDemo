using FluentAssertions;
using OpenITDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OpenITDemo.Tests
{
    [Binding]
    public sealed class TwitterStepDefinitions
    {
        private readonly ScenarioContext _context;

        private ITwitterLoginPage LoginPage;
        private ITwitterAccountPage AccountPage;

        private Dictionary<string, IBasePage> Pages;

        public TwitterStepDefinitions(ScenarioContext context)
        {
            _context = context;

            Pages = new Dictionary<string, IBasePage>
            {
                { "Login", LoginPage },
                { "Account", AccountPage },
            };
        }

        [Given(@"Open Twitter with (.*)")]
        public void GivenOpenTwitterWith(Device device)
        {
            // TODO: switch driver creation and pages initialization
        }

        [When(@"I do Log In with (.*) user")]
        public void WhenIDoLogInWith(string userAlias)
        {
            LoginPage.LogIn(Users.Get(userAlias));
        }

        [Then(@"(.*) page is loaded")]
        public void ThenPageIsLoaded(string pageName)
        {
            Pages[pageName].WaitForPageLoad();
        }

        [Then(@"I logged in with (.*) user")]
        public void ThenILoggedInWith(string userAlias)
        {
            AccountPage.Me.Should().BeEquivalentTo(Users.Get(userAlias).Login);
        }

        [When(@"I tweet (.*)")]
        public void WhenITweetHelloOpenITRand(string tweetText)
        {
            // TODO: add parsing tweetText with replace of rand:5 with 5 random chars
            var tweet = new Tweet
            {
                Message = tweetText,
            };
            _context.Add("tweet", tweet);
            AccountPage.Tweet(tweet);
        }

        [Then(@"My tweet is posted")]
        public void ThenMyTweetIsPosted()
        {
            var tweet = _context.Get<Tweet>("tweet");

            //TODO: step for waiting or refactor to add waiting

            AccountPage.MyTweets
                .Should().Contain(tweet);
        }


        public enum Device
        {
            Browser,
            Android,
            Desktop
        }
    }
}
