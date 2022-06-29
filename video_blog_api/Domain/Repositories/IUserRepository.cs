using video_blog_api.Domain.Models;

namespace video_blog_api.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<UserDTO>> Get();
		Task<UserDTO> Create(UserDTO user);
		Task Update(UserDTO user);
		Task Delete(int id);
	}
}
