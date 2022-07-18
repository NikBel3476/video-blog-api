using Domain.Core.Entities;

namespace Services.Interfaces
{
	public interface ILogin
	{
		LoginResult Login<LoginResult>(Account account);
	}
}