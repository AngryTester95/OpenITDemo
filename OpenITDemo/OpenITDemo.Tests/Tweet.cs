using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenITDemo.Tests
{
	public class Tweet : IEquatable<Tweet>
	{
		public string Message { get; set; }

		public bool Equals([AllowNull] Tweet other)
		{
			return other is Tweet
				&& Message == other.Message;
		}
	}
}
