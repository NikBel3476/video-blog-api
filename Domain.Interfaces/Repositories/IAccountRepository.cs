using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IAccountRepository
	{
		void Create(Account account);
		void Update(Account account);
		void Delete(Account account);
	}
}