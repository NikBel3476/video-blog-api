using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		Task<User?> FindAsync(long id);
		Task<User?> FindAsync(string name);
		Task<IEnumerable<User>> FindAllAsync();
		Task Create(Account account);
	}
}

