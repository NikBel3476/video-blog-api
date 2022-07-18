using Domain.Core.Entities;

namespace Domain.Interfaces
{
	public interface IUserRepository
	{
		User Get(long id);
		IEnumerable<User> GetAll();
	}
}
