using Domain.Core.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace video_blog_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		[HttpPost]
		public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
		{
			return StatusCode(501);
		}

		public async Task<ActionResult<RegistrationResponse>> Registration(RegistrationRequest request)
		{
			return StatusCode(501);
		}
	}
}
