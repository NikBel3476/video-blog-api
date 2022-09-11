using System.Net;
using Domain.API.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
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
		public async Task<ActionResult<GetAllRequest>> GetAll(
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 15
		) {
			try
			{
				return Ok(await _userService.GetAll(page, pageSize));
			}
			catch (ApiException e)
			{
				if (e.StatusCode == HttpStatusCode.NotFound)
				{
					return NotFound(e.Message);
				}
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetUser(string id)
		{
			return StatusCode(StatusCodes.Status501NotImplemented);
		}
	}
}
