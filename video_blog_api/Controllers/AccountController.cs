﻿using System.Net;
using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

namespace video_blog_api.Controllers
{
	[Microsoft.AspNetCore.Components.Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("registration")]
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

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(LoginRequest request)
		{
			return StatusCode(501);
			/*var user = await _userRepository.FindOne(userDto.login);
			if (user is null)
				return BadRequest("Пользователь с таким логином не найден");

			if (!PasswordSecurity.VerifyPassword(userDto.password, user.passwordHash))
				return BadRequest("Неверный пароль");

			return Ok(_jwtService.GenerateJwtToken(user));*/
		}
	}
}
