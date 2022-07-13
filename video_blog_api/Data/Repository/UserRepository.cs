using Microsoft.EntityFrameworkCore;
using video_blog_api.Data.Database;
using video_blog_api.Data.Models;
using video_blog_api.Domain.Repositories;

namespace video_blog_api.Data.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;
		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<User>> FindAll()
		{
			return await _context.users.ToListAsync();
		}

		public async Task<User?> FindOne(long id)
		{
			return await _context.users.FindAsync(id);
		}

		public async Task<User?> FindOne(string login)
		{
			return await _context.users.FirstOrDefaultAsync(u => u.login == login);
		}

		public async Task<User> Create(User user)
		{
			var userEntry = _context.users.Add(user);
			await _context.SaveChangesAsync();
			return userEntry.Entity;
		}

		public async Task<User> Update(User user)
		{
			var userEntry = _context.Entry(user);
			userEntry.State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return userEntry.Entity;
		}

		public async Task<User> Delete(User user)
		{
			var userEntry = _context.users.Remove(user);
			await _context.SaveChangesAsync();
			return userEntry.Entity;
		}
	}
}
