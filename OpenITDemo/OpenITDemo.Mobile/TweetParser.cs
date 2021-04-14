using OpenITDemo.Domain;
using System;

namespace OpenITDemo.Mobile
{
	internal static class TweetParser
	{
		public static Tweet ParseTweet(string content)
		{
			var parts = content.Split(". ", StringSplitOptions.RemoveEmptyEntries);

			var message = parts[1];
			return new Tweet { Message = message };
		}
	}
}
