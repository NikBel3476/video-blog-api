namespace video_blog_api.Data.Models
{
	public class User
	{
		public int id { get; set; }
		public string name { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public string hash { get; set; }
		public string salt { get; set; }
	}
}
