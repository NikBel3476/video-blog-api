using System.Net;
using Domain.Core.Authentication;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using video_blog_api.Domain.Models;
using video_blog_api.Security;
using video_blog_api.Utils.Jwt;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;
		private readonly JwtService _jwtService;

		public AccountController(
			JwtService jwtService,
			IAccountService accountService
		)
		{
			_jwtService = jwtService;
			_accountService = accountService;
		}
		
		[HttpPost("registration")]
		public async Task<ActionResult<string>> Registration(RegistrationRequest request)
		{
			try
			{
				return Ok(await _accountService.RegistrationAsync(request));
			} catch (ApiException e)
			{
				if (e.StatusCode == HttpStatusCode.BadRequest)
					return BadRequest(e.Message);

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(UserDTO userDto)
		{
			var user = await _userRepository.FindOne(userDto.login);
			if (user is null)
				return BadRequest("Пользователь с таким логином не найден");

			if (!PasswordSecurity.VerifyPassword(userDto.password, user.passwordHash))
				return BadRequest("Неверный пароль");

			return Ok(_jwtService.GenerateJwtToken(user));
		}
	}
}
