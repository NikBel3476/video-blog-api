using Microsoft.EntityFrameworkCore;
using video_blog_api.Data.Database;
using video_blog_api.Domain.Models;
using video_blog_api.Data.Models;
using video_blog_api.Security;
using video_blog_api.Utils;
using video_blog_api.Domain.Repositories;

namespace video_blog_api.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;
		public UserRepository(ApplicationContext context)
		{
			_context = context;
		}
		public async Task<UserDTO> Create(UserDTO user)
		{
			User userData = CustomUserMap.MapToData(user);
			PasswordSecurity.GeneratePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);
			userData.hash = Convert.ToBase64String(passwordHash);
			userData.salt = Convert.ToBase64String(passwordSalt);
			_context.users.Add(userData);
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

		public async Task<IEnumerable<UserDTO>> Get()
		{
			var users = await _context.users.ToListAsync();
			return CustomUserMap.MapToDTO(users);
		}

		public async Task Update(UserDTO userDto)
		{
			var userData = CustomUserMap.MapToData(userDto);
			_context.Entry(userData).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
