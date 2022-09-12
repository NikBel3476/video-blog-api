using Domain.Entities;

namespace Domain.API.Users
{
	public class GetAllResponse
	{
		public IEnumerable<User> Users { get; set; }
		public long TotalCount { get; set; }
	}
}
