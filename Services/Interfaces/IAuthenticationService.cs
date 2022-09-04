using Domain.Authentication;

namespace Services.Interfaces
{
	public interface IAuthenticationService
	{
		Task<LoginResponse> LoginAsync(LoginRequest request);
		Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
	}
}
