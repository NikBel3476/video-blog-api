using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
		private readonly IConfiguration _configuration;
		private readonly IUserRepository _userRepository;

		public AccountController(IConfiguration configuration, IUserRepository userRepository)
		{
			_configuration = configuration;
			_userRepository = userRepository;
		}

		[AllowAnonymous]
		[HttpPost("registration")]
		public async Task<ActionResult<string>> CreateUser([FromBody] UserDTO userDto)
		{
			try
			{
				User user = CustomUserMap.MapToData(userDto);
				var candidate = await _userRepository.FindOne(userDto.login);
				if (candidate is not null)
					return BadRequest("Пользователь с таким логином уже существует");

				PasswordSecurity.GeneratePasswordHash(userDto.password, out byte[] passwordHash, out byte[] passwordSalt);
				user.passwordHash = Convert.ToBase64String(passwordHash);
				user.passwordSalt = Convert.ToBase64String(passwordSalt);
				var createdUser = await _userRepository.Create(user);

				return Ok(GenerateJwtToken(createdUser));
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<string>> Login([FromBody] UserDTO userDto)
		{
			try
			{
				var user = await _userRepository.FindOne(userDto.login);
				if (user is null)
					return BadRequest("Пользователь с таким логином не найден");

				if (
					!PasswordSecurity.VerifyPassword(
					    userDto.password,
					    Convert.FromBase64String(user.passwordHash),
					    Convert.FromBase64String(user.passwordSalt)
					)
				)
				{
					return BadRequest("Неверный пароль");
				}

				return Ok(GenerateJwtToken(user));
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

		private string GenerateJwtToken(User user)
		{
			// TODO: move to separate method
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.login),
				new Claim(ClaimTypes.GivenName, user.name)
			};

			var token = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
