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
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly JwtSettings _jwtSettings;

		public AccountService(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			IOptions<JwtSettings> jwtSettings
		) {
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;
		}

		public async Task<LoginResponse> LoginAsync(LoginRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
				throw new ApiException(HttpStatusCode.BadRequest,"User was not found");

			var result = await _signInManager.PasswordSignInAsync(
				user,
				request.Password,
				false,
				false
			);

			if (!result.Succeeded)
				throw new ApiException(HttpStatusCode.BadRequest, "Wrong password");

			JwtSecurityToken accessToken = await GenerateJwtTokenAsync(
				user,
				Convert.ToInt64(TimeSpan.FromHours(3).TotalMilliseconds)
			);

			JwtSecurityToken refreshToken = await GenerateJwtTokenAsync(
				user,
				Convert.ToInt64(TimeSpan.FromDays(3).TotalMilliseconds)
			);

			return new LoginResponse
			{
				Id = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
				RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken) 
			};
		}

		public async Task<RegistrationResponse> RegistrationAsync(RegistrationRequest request)
		{
			var existingUser = await _userManager.FindByEmailAsync(request.Email);
			if (existingUser != null)
				throw new ApiException(
					HttpStatusCode.BadRequest,
					$"User with the Email '{request.Email}' already exists"
				);

			var user = new ApplicationUser
			{
				UserName = request.UserName,
				Email = request.Email
			};

			var result = await _userManager.CreateAsync(user, request.Password);
			if (!result.Succeeded)
				throw new ApiException(
					HttpStatusCode.BadRequest,
					$"{result.Errors.ToList()[0].Description}"
				);
			
			await _signInManager.SignInAsync(user, false);

			var accessToken = await GenerateJwtTokenAsync(
				user,
				Convert.ToInt64(TimeSpan.FromHours(3).TotalMilliseconds)
			);
			var refreshToken = await GenerateJwtTokenAsync(
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

		private async Task<JwtSecurityToken> GenerateJwtTokenAsync(ApplicationUser user, long durationInMs)
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
