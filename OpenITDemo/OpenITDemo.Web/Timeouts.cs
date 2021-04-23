using System;

namespace OpenITDemo.Web
{
	public static class Timeouts
	{
		public static TimeSpan Wait { get; } = TimeSpan.FromSeconds(10);
	}
}
