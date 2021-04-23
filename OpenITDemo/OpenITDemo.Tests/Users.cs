using OpenITDemo.Domain;

namespace OpenITDemo.Tests
{
	public class Users
	{
		public static User Get(string userAlias)
		{
			return typeof(Users)
				.GetProperty(userAlias)
				.GetValue(null) 
				as User;
		}

		public static User OpenITDemoUser { get; } = new User
		{ 
			Login = new Login("{user-login}"),
			Password = "{user-password}",
		};
	}
}
