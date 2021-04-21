using System.Collections.Generic;

namespace OpenITDemo.Domain
{
	public interface ITwitterAccountPage : IBasePage
	{
		Login Me { get; }

		List<Tweet> MyTweets { get; }

		void Tweet(Tweet tweet);
	}
}
