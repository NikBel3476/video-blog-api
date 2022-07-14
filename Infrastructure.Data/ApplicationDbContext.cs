using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Account> Accounts => Set<Account>();
	}
}