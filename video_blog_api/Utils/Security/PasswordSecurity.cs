using System.Security.Cryptography;
using System.Text;

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
		public static string GeneratePasswordHash(string password) =>
			BCrypt.Net.BCrypt.HashPassword(password);
		public static bool VerifyPassword(string passwordToSubmit, string hashedPassword) =>
			BCrypt.Net.BCrypt.Verify(passwordToSubmit, hashedPassword);
	}
}
