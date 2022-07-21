using Domain.Core.Entities;

namespace Services.Interfaces
{
	public interface ILogout
	{
		void Logout(Account account);
	}
}
