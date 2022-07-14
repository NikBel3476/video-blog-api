using Domain.Core;

namespace Domain.Interfaces
{
	public interface IUserRepository
	{
		User Get(long id);
		IEnumerable<User> GetAll();
	}
}
