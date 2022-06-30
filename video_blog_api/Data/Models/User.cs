namespace video_blog_api.Data.Models
{
	public class User
	{
		public long id { get; set; } = default!;
		public string name { get; set; } = string.Empty;
		public string login { get; set; } = string.Empty;
		public string passwordHash { get; set; } = string.Empty;
		public string passwordSalt { get; set; } = string.Empty;
	}
}
