using System.IdentityModel.Tokens.Jwt;

namespace Domain.Authentication
{
	public class RegistrationResponse
	{
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}
