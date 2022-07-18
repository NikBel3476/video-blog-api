namespace Domain.Core.Entities
{
	public class Account : User
	{
		public string Password { get; set; } = string.Empty;
	}
}
