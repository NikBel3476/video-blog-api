using Microsoft.AspNetCore.Mvc;
using video_blog_api.Data.Models;
using video_blog_api.Domain.Models;
using video_blog_api.Domain.Repositories;
using video_blog_api.Security;
using video_blog_api.Utils;

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
		public async Task<ActionResult<IEnumerable<UserDTO>?>> GetAllUsers()
		{
			return Ok(CustomUserMap.MapToDTO(await _userRepository.FindAll()));
		}

		[HttpPost("registration")]
		public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDto)
		{
			try
			{
				User user = CustomUserMap.MapToData(userDto);
				var candidate = await _userRepository.FindOne(userDto.login);
				if (candidate is not null)
					return BadRequest("Пользователь с таким логином уже существует");
				PasswordSecurity.GeneratePasswordHash(userDto.password, out byte[] passwordHash, out byte[] passwordSalt);
				user.hash = Convert.ToBase64String(passwordHash);
				user.salt = Convert.ToBase64String(passwordSalt);
				var createdUser = await _userRepository.Create(user);
				return Ok(CustomUserMap.MapToDTO(createdUser));
			}
			catch (Exception)
			{
				return StatusCode(500);
			} 
		}
 
		[HttpDelete("delete")]
		public async Task<ActionResult<UserDTO>> DeleteUser(long id)
		{
			try
			{
				var user = await _userRepository.FindOne(id);
				if (user is null) 
					return NotFound("Пользователь не найден");
				var deletedUser = await _userRepository.Delete(user);
				return Ok(deletedUser);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}
		
		[HttpPut("update")]
		public async Task<ActionResult> UpdatePerson(UserDTO user)
		{
			return StatusCode(501);
			//try
			//{
			//	await _userRepository.Update(user);
			//	return true;
			//}
			//catch (Exception)
			//{
			//	return false;
			//}
		}
	}
}
