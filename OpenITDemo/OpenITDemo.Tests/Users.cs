using OpenITDemo.Domain;

namespace OpenITDemo.Tests
{
	public class Users
	{
		public static User OpenITDemoUser { get; } = new User
		{ 
			Login = new Login("demo_open"),
			Password = "zaq123ZAQ!@#",
		};
	}
}
