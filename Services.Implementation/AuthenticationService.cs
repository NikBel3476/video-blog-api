using Domain.Core.Authentication;
using Domain.Core.Entities;
using Infrastructure.Repositories;
using Services.Interfaces;
using Services.Utils.Password;

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

		public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
		{
			var existingUser = await _unitOfWork.User.FindAsync(request.Name);
			if (existingUser != null)
			{
				throw new Exception("User already exist");
			}

			var passwordHash = PasswordSecurity.GeneratePasswordHash(request.Password);

			var account = new Account()
			{
				Name = request.Name,
				Login = request.Login,
				Password = passwordHash
			};

			// TODO: complete method
			await _unitOfWork.User.Create(account);
		}
	}
}
