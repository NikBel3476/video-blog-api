using Domain.API.Users;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Implementation
{
	public class UserService : IUserService
	{
		public Task<User> GetUserById(string id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetUserByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public Task<GetAllResponse> GetAll(int page, int pageSize)
		{
			throw new NotImplementedException();
		}
	}
}
