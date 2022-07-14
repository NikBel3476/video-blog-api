using Domain.Core;

namespace Domain.Interfaces
{
	public interface IAccountRepository
	{
		User Get(long id);
		IEnumerable<User> GetAll();
		void Create(User account);
		void Update(User account);
		void Delete(long id);
	}
}