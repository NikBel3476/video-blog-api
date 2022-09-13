using System.Net;
using Domain.API.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

namespace video_blog_api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
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
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetUser(string id)
		{
			try
			{
				return Ok(await _userService.GetUserByIdAsync(id));
			}
			catch (ApiException e)
			{
				if (e.StatusCode == HttpStatusCode.NotFound)
					return NotFound(e.Message);

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}
	}
}
