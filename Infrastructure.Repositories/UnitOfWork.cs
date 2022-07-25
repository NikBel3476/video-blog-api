using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IDisposable
	{
		private readonly ApplicationDbContext _context;
		private bool _disposed;

		private AccountRepository? accountRepository;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public AccountRepository Account
		{
			get
			{
				if (accountRepository == null)
				{
					accountRepository = new AccountRepository(_context);
				}
				return accountRepository;
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
