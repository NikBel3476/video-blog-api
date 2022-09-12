namespace Domain.Entities
{
	public class Account : ApplicationUser
	{
		public string Password { get; set; } = string.Empty;
	}
}
