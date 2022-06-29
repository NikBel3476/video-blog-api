using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace video_blog_api.Security
{
	public static class PasswordSecurity
	{
		private const ushort SALT_BYTES_SIZE = 128 / 8;
		private const int ITERATION_COUNT = 100000;
		private const ushort NUM_BYTES = 512 / 8;

		/// <summary>
		/// Generate hash key
		/// </summary>
		/// <param name="password">String to hash</param>
		/// /// <param name="passwordHash">Hash based on password and salt</param>
		/// <param name="passwordSalt">Salt to hash</param>
		/// <returns>Hash key byte array</returns>
		public static void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			passwordSalt = new byte[SALT_BYTES_SIZE];

			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
			}

			passwordHash = KeyDerivation.Pbkdf2(
				password: password,
				salt: passwordSalt,
				prf: KeyDerivationPrf.HMACSHA512,
				iterationCount: ITERATION_COUNT,
				numBytesRequested: NUM_BYTES
			);
		}
		public static bool VerifyPassword()
		{
			throw new NotImplementedException();
		}
	}
}
