using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		User Get(long id);
		IEnumerable<User> GetAll();
	}
}
