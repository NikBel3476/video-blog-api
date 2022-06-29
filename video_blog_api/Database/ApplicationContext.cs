using Microsoft.EntityFrameworkCore;
using video_blog_api.Models;

namespace video_blog_api.Database
{
	public class ApplicationContext: DbContext
	{
		public DbSet<User> users { get; set; }
		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasKey(c => new { c.id });
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=localhost;Database=blog_video;Port=5432;Ssl Mode=Prefer;User Id=postgres;Password=postgres");
		}
	}
}
