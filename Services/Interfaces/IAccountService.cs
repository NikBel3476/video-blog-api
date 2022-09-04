using Domain.Core.Authentication;

namespace Services.Interfaces
{
	public interface IAccountService
	{
		Task<LoginResponse> LoginAsync(LoginRequest request);
		Task<RegistrationResponse> RegistrationAsync(RegistrationRequest request);
		Task LogoutAsync();
	}
}
