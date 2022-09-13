using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class IdentityContext : IdentityDbContext<ApplicationUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
		}
	}
}
