﻿/*
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationDbContext _context;

		public AccountRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Account?> FindByEmailAsync(string email) =>
			await _context.Accounts.FirstOrDefaultAsync(u => u.Email == email);

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
*/
