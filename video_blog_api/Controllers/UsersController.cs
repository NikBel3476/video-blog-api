using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_blog_api.Domain.Models;
using video_blog_api.Domain.Repositories;
using video_blog_api.Utils;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class UsersController : ControllerBase
	{
		private IUserRepository _userRepository;

		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDTO>?>> GetAllUsers()
		{
			return Ok(CustomUserMap.MapToDTO(await _userRepository.FindAll()));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserDTO?>> GetUser(long id)
		{
			var user = await _userRepository.FindOne(id);
			if (user is null)
				return NotFound("Пользователь не найден");
			return Ok(CustomUserMap.MapToDTO(user));
		}
	}
}
