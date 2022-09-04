using Domain.Core.Entities;

namespace Services.Interfaces
{
	public interface ILogin
	{
		void Login(Account account);
	}
}