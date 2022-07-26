namespace Services.Utils.Password
{
	public static class PasswordSecurity
	{
		public static string GeneratePasswordHash(string password) =>
			BCrypt.Net.BCrypt.HashPassword(password);
		public static bool VerifyPassword(string passwordToSubmit, string hashedPassword) =>
			BCrypt.Net.BCrypt.Verify(passwordToSubmit, hashedPassword);
	}
}
