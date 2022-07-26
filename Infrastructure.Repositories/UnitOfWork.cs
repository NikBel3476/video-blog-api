using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IDisposable
	{
		private readonly ApplicationDbContext _context;
		private bool _disposed;

		private UserRepository? _userRepository;
		private AccountRepository? _accountRepository;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public UserRepository User
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_context);
				}
				return _userRepository;
			}
		}

		public AccountRepository Account
		{
			get
			{
				if (_accountRepository == null)
				{
					_accountRepository = new AccountRepository(_context);
				}
				return _accountRepository;
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
