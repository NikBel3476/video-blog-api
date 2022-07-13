namespace video_blog_api.Data.Models
{
	public class AuthResponse
	{
		public string accessToken;

		public AuthResponse(string AccessToken)
		{
			accessToken = AccessToken;
		}
	}
}
