using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Domain.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using Services.Interfaces;
using Services.Settings;

namespace Services.Implementation
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly JwtSettings _jwtSettings;

		public AccountService(UserManager<User> userManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings.Value;
		}

		public async Task<LoginResponse> LoginAsync(LoginRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<RegistrationResponse> RegistrationAsync(RegistrationRequest request)
		{
			var existingUser = await _userManager.FindByEmailAsync(request.Email);
			if (existingUser != null)
			{
				throw new ApiException(
					HttpStatusCode.BadRequest,
					$"User with the Email '{request.Email}' already exists"
				);
			}
			
			var user = new User
			{
				UserName = request.UserName,
				Email = request.Email
			};

			var result = await _userManager.CreateAsync(user, request.Password);
			if (!result.Succeeded)
				throw new ApiException(HttpStatusCode.BadRequest, $"{result.Errors.ToList()[0].Description}");

			var accessToken = await GenerateJwtToken(
				user,
				Convert.ToInt64(TimeSpan.FromHours(3).TotalMilliseconds)
			);
			var refreshToken = await GenerateJwtToken(
				user,
				Convert.ToInt64(TimeSpan.FromDays(3).TotalMilliseconds)
			);

			return new RegistrationResponse
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
				RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
			};
		}

		public Task LogoutAsync()
		{
			throw new NotImplementedException();
		}

		private async Task<JwtSecurityToken> GenerateJwtToken(User user, long durationInMs)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Name, user.UserName),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("id", user.Id)
			}.Union(userClaims);

			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
				SecurityAlgorithms.HmacSha256
			);

			return new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMilliseconds(durationInMs),
				signingCredentials: signingCredentials
			);
		}
	}
}
