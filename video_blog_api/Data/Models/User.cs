namespace video_blog_api.Data.Models
{
	public class User
	{
		public int id { get; set; } = default!;
		public string name { get; set; } = string.Empty;
		public string login { get; set; } = string.Empty;
		public string password { get; set; } = string.Empty;
		public string hash { get; set; } = string.Empty;
		public string salt { get; set; } = string.Empty;
	}
}
