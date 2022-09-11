using System.ComponentModel.DataAnnotations;

namespace Domain.Authentication
{
	public class RegistrationRequest
	{
		[Required(ErrorMessage = "No user name entered")]
		public string UserName { get; set; } = string.Empty;
		[Required(ErrorMessage = "No email entered")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "No password entered")]
		[MinLength(6, ErrorMessage = "The password length must be at least 6 characters")]
		public string Password { get; set; } = string.Empty;

		[Required(ErrorMessage = "No password confirmation entered")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}
