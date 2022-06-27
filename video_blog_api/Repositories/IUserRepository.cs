using video_blog_api.Models;

namespace video_blog_api.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> Get();
		Task<User> Create(User user);
		Task Update(User user);
		Task Delete(int id);
	}
}
