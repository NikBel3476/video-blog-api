using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users => Set<User>();
	}
}