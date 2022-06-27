using Microsoft.EntityFrameworkCore;
using video_blog_api.Database;
using video_blog_api.Models;

namespace video_blog_api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		public UserRepository(ApplicationContext context)
		{
			_context = context;
		}
		public Task<List<User>> Create(List<User> countryData)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<User>> Get()
		{
			return await _context.users.ToListAsync();
		}

		public Task Update(User countryData)
		{
			throw new NotImplementedException();
		}
	}
}
