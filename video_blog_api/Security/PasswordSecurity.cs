using System.Security.Cryptography;

namespace video_blog_api.Security
{
	public class PasswordSecurity
	{
		const int SALT_BYTES = 24;
		const int KEY_BYTES = 24;

		/// <summary>
		/// Generates string that contains hash and salt
		/// </summary>
		/// <param name="inputString">String to hash</param>
		/// <returns>String format hash:salt</returns>
		public static string GenerateHash(string inputString)
		{
			byte[] salt = new byte[SALT_BYTES];

			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			byte[] hash = HashWithPBKDF2(inputString, salt, KEY_BYTES);
			
			return $"{Convert.ToBase64String(hash)}:{Convert.ToBase64String(salt)}";
		}


		public static bool VerifyPassword()
		{
			return true;
		}

		/// <summary>
		/// Generate hash key
		/// </summary>
		/// <param name="password">String to hash</param>
		/// <param name="salt">Salt to hash</param>
		/// <param name="outputBytes">The number of pseudo-random key bytes for this object</param>
		/// <returns>Hash key byte array</returns>
		private static byte[] HashWithPBKDF2(string password, byte[] salt, int outputBytes)
		{
			using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt))
			{
				return pbkdf2.GetBytes(outputBytes);
			}
		}
	}
}
