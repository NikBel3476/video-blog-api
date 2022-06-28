using Microsoft.AspNetCore.Mvc;
using video_blog_api.Models;
using video_blog_api.Repositories;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public AccountController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet("getUsers")]
		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await _userRepository.Get();
		}

		[HttpPost("registerUser")]
		public async Task<bool> CreateUser(User user)
		{
			try
			{
				await _userRepository.Create(user);
				return true;
			}
			catch (Exception)
			{
				return false;
			} 
		}
 
		[HttpDelete("deleteUser")]
		public async Task<bool> DeleteUser(int id)
		{
			try
			{
				await _userRepository.Delete(id);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		[HttpPut("UpdatePerson")]
		public async Task<bool> UpdatePerson(User user)
		{
			try
			{
				await _userRepository.Update(user);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
