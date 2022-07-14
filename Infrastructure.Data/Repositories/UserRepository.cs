using Domain.Core;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		public User Get(long id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
