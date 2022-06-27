using video_blog_api.Models;

namespace video_blog_api.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> Get();
		Task<List<User>> Create(List<User> users);
		Task Update(User user);
		Task Delete(int id);
	}
}
