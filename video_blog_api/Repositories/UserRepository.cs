using Microsoft.EntityFrameworkCore;
using video_blog_api.Database;
using video_blog_api.Models;
using video_blog_api.Security;

namespace video_blog_api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		public UserRepository(ApplicationContext context)
		{
			_context = context;
		}
		public async Task<User> Create(User user)
		{
			PasswordSecurity.GeneratePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);
			user.hash = Convert.ToBase64String(passwordHash);
			user.salt = Convert.ToBase64String(passwordSalt);
			_context.users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task Delete(int id)
		{
			var userToDelete = await _context.users.FindAsync(id);
			if (userToDelete == null) return;

			_context.users.Remove(userToDelete);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> Get()
		{
			return await _context.users.ToListAsync();
		}

		public async Task Update(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
