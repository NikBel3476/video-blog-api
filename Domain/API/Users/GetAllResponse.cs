using Domain.Entities;

namespace Domain.API.Users
{
	public class GetAllResponse
	{
		public IEnumerable<User> Users { get; set; } = new List<User>();
		public long TotalCount { get; set; }
	}
}
