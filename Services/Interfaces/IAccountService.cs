using Domain.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
	public interface IAccountService
	{
		Task<LoginResponse> LoginAsync(LoginRequest request);
		Task<ChallengeResult> LoginGoogleAsync(string redirectUrl);
		Task<RegistrationResponse> RegistrationAsync(RegistrationRequest request);
		Task LogoutAsync();
		Task<ApplicationUser> GoogleSignInResponse();
	}
}
