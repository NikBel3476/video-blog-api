using Domain.Core.Entities;
using Infrastructure.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_blog_api.Security;
using video_blog_api.Utils.Jwt;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private AccountRegistration _accountRegistration;
		private JwtService _jwtService;

		public AccountController(
			AccountRegistration accountRegistration,
			JwtService jwtService
		)
		{
			_accountRegistration = accountRegistration;
			_jwtService = jwtService;
		}

		[AllowAnonymous]
		[HttpPost("registration")]
		public async Task<ActionResult<string>> CreateUser(Account account)
		{
			var result = _accountRegistration.Register(account);
			var candidate = await _userRepository.FindOne(userDto.login);
			if (candidate is not null)
				return BadRequest("Пользователь с таким логином уже существует");

			user.passwordHash = PasswordSecurity.GeneratePasswordHash(userDto.password);
			var createdUser = await _userRepository.Create(user);

			return Ok(_jwtService.GenerateJwtToken(createdUser));
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

		// FIXME: replace id to token
		[HttpDelete("delete")]
		public async Task<ActionResult<UserDTO>> DeleteUser(long id)
		{

			var user = await _userRepository.FindOne(id);
			if (user is null)
				return NotFound("Пользователь не найден");
			var deletedUser = await _userRepository.Delete(user);
			return Ok(deletedUser);
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
