using Domain.Core.Entities;

namespace Services.Interfaces
{
	public interface IRegistration
	{
		RegisterResult Register<RegisterResult>(Account account);
	}
}
