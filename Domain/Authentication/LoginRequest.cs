namespace Domain.Authentication
{
	public class LoginRequest
	{
		string Login { get; set; } = string.Empty;
		string Password { get; set; } = string.Empty;
	}
}
