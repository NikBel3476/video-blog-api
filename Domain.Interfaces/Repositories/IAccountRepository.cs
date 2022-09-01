using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IAccountRepository
	{
		Task<Account?> FindByLoginAsync(string login);
		Task<Account> CreateAsync(Account account);
		void Update(Account account);
		void Delete(Account account);
	}
}
