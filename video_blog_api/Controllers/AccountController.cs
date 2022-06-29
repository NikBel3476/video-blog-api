using Microsoft.AspNetCore.Mvc;
using video_blog_api.Domain.Models;
using video_blog_api.Domain.Repositories;

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

		[HttpGet("all")]
		public async Task<IEnumerable<UserDTO>> GetAllUsers()
		{
			return await _userRepository.Get();
		}

		[HttpPost("register")]
		public async Task<bool> CreateUser(UserDTO user)
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
 
		[HttpDelete("delete")]
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
		
		[HttpPut("update")]
		public async Task<bool> UpdatePerson(UserDTO user)
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
