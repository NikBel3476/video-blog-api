﻿namespace Domain.Core.Authentication
{
	public class RegistrationResponse
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Login { get; set; } = string.Empty;
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}
