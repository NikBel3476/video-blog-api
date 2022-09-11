using Domain.API.Users;
using Domain.Entities;

namespace Services.Interfaces
{
	public interface IUserService
	{
		Task<User> GetUserById(string id);
		Task<User> GetUserByEmail(string email);
		Task<GetAllResponse> GetAll(int page, int pageSize);
	}
}
