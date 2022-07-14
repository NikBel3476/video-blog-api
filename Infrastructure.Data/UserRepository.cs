using Domain.Core;
using Domain.Interfaces;

namespace Infrastructure.Data
{
	public class UserRepository : IAccountRepository
	{
		public void Create(User account)
		{
			throw new NotImplementedException();
		}

		public void Delete(long id)
		{
			throw new NotImplementedException();
		}

		public User Get(long id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(User account)
		{
			throw new NotImplementedException();
		}
	}
}
