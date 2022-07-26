using Domain.Core.Authentication;
using Infrastructure.Repositories;
using Services.Interfaces;

namespace Services.Implementation
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly UnitOfWork _unitOfWork;
		public AuthenticationService(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Task<LoginResponse> LoginAsync(LoginRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
