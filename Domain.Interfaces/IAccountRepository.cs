using Domain.Core;

namespace Domain.Interfaces
{
	public interface IAccountRepository
	{
		void Create(Account account);
		void Update(Account account);
		void Delete(Account account);
	}
}