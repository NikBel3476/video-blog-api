using Domain.Core.Entities;

namespace Services.Interfaces
{
	public interface ILogout
	{
		LogoutResult Logout<LogoutResult>(Account account);
	}
}
