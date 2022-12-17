using Domain.API.Users;
using Domain.Entities;

namespace Services.Interfaces
{
	public interface IUserService
	{
		Task<User?> GetUserByIdAsync(string id);
		Task<User> GetUserByEmailAsync(string email);
		Task<GetAllResponse> GetAllAsync(int page, int pageSize);
	}
}
