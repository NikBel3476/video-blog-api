using System.Net;
using Domain.Core.Authentication;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Exceptions;
using Services.Interfaces;

namespace Services.Implementation
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;
		
		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}
		public async Task Login(LoginRequest request)
		{
			throw new NotImplementedException();
		}
		
		public async Task<RegistrationResponse> RegistrationAsync(RegistrationRequest request)
		{
			var existingUser = await _accountRepository.FindByLoginAsync(request.Login);
			if (existingUser != null)
			{
				throw new ApiException(
					HttpStatusCode.BadRequest, 
					$"User with the login '{request.Login}' already exists"
				);
			}

			// TODO: complete registration logic
			var account = new Account
			{
				
			};
			var user = _accountRepository.CreateAsync(account);

			return new RegistrationResponse();
		}

		public Task Logout()
		{
			throw new NotImplementedException();
		}
	}
}
