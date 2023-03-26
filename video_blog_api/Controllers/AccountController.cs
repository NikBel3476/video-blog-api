using System.Net;
using Domain.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

namespace video_blog_api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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
				{
					return BadRequest(e.Message);
				}

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpPost("login")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
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
				{
					return BadRequest(e.Message);
				}

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpGet("signin-google")]
		public async Task<IActionResult> GoogleLogin()
		{
			var redirectUrl = Url.Action("GoogleResponse", "Account");
			if (redirectUrl == null)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

			return await _accountService.LoginGoogleAsync(redirectUrl);
		}

		[HttpGet("google-response")]
		public async Task<IActionResult> GoogleResponse()
		{
			try
			{
				var user = await _accountService.GoogleSignInResponse();
				return Ok(user);
			}
			catch (ApiException e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("getData")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<String>> GetData()
		{
			return Ok(new { message = "Hello World!" });
		}
	}
}
