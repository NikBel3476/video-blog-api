using video_blog_api.Data.Models;

namespace video_blog_api.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<List<User>> FindAll();
		Task<User?> FindOne(long id);
		Task<User?> FindOne(string login);
		Task<User> Create(User user);
		Task<User> Update(User user);
		Task<User> Delete(User user);
	}
}
