using Domain.Entities;

namespace Domain.Interfaces
{
	public interface IAccountRepository
	{
		Task<Account?> FindByEmailAsync(string login);
		Task<Account> CreateAsync(Account account);
		void Update(Account account);
		void Delete(Account account);
	}
}
