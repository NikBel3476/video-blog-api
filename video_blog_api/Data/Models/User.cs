using System.ComponentModel.DataAnnotations;

namespace video_blog_api.Data.Models
{
	public class User
	{
		[Key]
		public long id { get; set; }
		public string name { get; set; } = string.Empty;
		public string login { get; set; } = string.Empty;
		public string passwordHash { get; set; } = string.Empty;
	}
}
