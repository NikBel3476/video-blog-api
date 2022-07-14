using Domain.Core;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationDbContext _context;

		public AccountRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Create(Account account)
		{
			throw new NotImplementedException();
		}

		public void Delete(Account account)
		{
			throw new NotImplementedException();
		}

		public void Update(Account account)
		{
			throw new NotImplementedException();
		}
	}
}
