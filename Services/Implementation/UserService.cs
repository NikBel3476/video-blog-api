using Domain.API.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		
		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		
		public Task<User> GetUserByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetUserByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<GetAllResponse> GetAllAsync(int page, int pageSize)
		{
			var users = await _userManager.Users
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.Select(user => new User
				{
					Id = user.Id,
					UserName = user.UserName,
					Email = user.Email
				})
				.ToListAsync();

			var count = await _userManager.Users.CountAsync();
			return new GetAllResponse { Users = users, TotalCount = count };
		}
	}
}
