using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Database
{
	public class UserContext : DbContext
	{
		public DbSet<User> Users => Set<User>();
	}
}