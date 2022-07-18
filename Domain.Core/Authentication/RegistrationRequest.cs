namespace Domain.Core.Authentication
{
	public class RegistrationRequest
	{
		string Name { get; set; } = string.Empty;
		string Login { get; set; } = string.Empty;
		string Password { get; set; } = string.Empty;
	}
}
