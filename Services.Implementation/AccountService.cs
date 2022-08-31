using Domain.Core.Authentication;
using Services.Interfaces;

namespace Services.Implementation
{
	public class AccountService : IAccountService
	{
		public AccountService(IAccountRepository)
		{
			
		}
		public Task Login(LoginRequest request)
		{
			throw new NotImplementedException();
		}
		
		public Task RegistrationAsync(RegistrationRequest request)
		{
			throw new NotImplementedException();
		}

		public Task Logout()
		{
			throw new NotImplementedException();
		}
	}
}