using Domain.API.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<GetAllResponse>> GetAll(
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 10
		)
		{
			return Ok(await _userService.GetAllAsync(page, pageSize));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetUser(string id)
		{
			return StatusCode(StatusCodes.Status501NotImplemented);
		}
	}
}
