﻿namespace Domain.Entities
{
	public class Account : User
	{
		public string Password { get; set; } = string.Empty;
	}
}