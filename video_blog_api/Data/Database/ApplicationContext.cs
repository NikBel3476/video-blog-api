using Microsoft.EntityFrameworkCore;
using video_blog_api.Data.Models;

namespace video_blog_api.Data.Database
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<User> users { get; set; } = default!;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasKey(u => u.id);
			modelBuilder.Entity<User>().HasAlternateKey(u => u.login);
			modelBuilder.Entity<User>().HasIndex(u => u.login);
		}
	}
}
