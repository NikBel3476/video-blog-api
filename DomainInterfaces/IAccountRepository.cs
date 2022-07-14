namespace Domain.Interfaces
{
	public interface IAccountRepository
	{
		Account Get(long id);
		void Create(Account account);
		void Update(Account account);
		void Delete(Account account);
	}
}