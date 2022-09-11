using System.Net;
using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("registration")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<RegistrationResponse>> Registration(RegistrationRequest request)
		{
			try
			{
				return Ok(await _accountService.RegistrationAsync(request));
			}
			catch (ApiException e)
			{
				if (e.StatusCode == HttpStatusCode.BadRequest)
					return BadRequest(e.Message);

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}
		
		[HttpPost("login")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
		{
			try
			{
				return await _accountService.LoginAsync(request);
			}
			catch (ApiException e)
			{
				if (e.StatusCode == HttpStatusCode.BadRequest)
					return BadRequest(e.Message);

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}
	}
}
