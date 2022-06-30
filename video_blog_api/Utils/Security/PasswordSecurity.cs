using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace video_blog_api.Security
{
	public static class PasswordSecurity
	{
		/// <summary>
		/// Generate hash key
		/// </summary>
		/// <param name="password">String to hash</param>
		/// /// <param name="passwordHash">Hash based on password and salt</param>
		/// <param name="passwordSalt">Salt to hash</param>
		/// <returns>Hash key byte array</returns>
		public static void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using var hmac = new HMACSHA512();
			passwordSalt = hmac.Key;
			passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}
		public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using var hmac = new HMACSHA512(passwordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			return computedHash.SequenceEqual(passwordHash);
		}
	}
}
