using System;
using APIService.Data;

namespace APIService.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly APIServiceContext _context;

		public UnitOfWork(APIServiceContext context)
		{
			this._context = context;
		}

		public IAPIDefinitionRepo APIDefinitionRepo => new APIDefinitionRepo(_context);

        public IAPIFieldRepo APIFieldRepo => new APIFieldRepo(_context);

        public IUserRepo UserRepo => new UserRepo(_context);

        public async Task<bool> SaveAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
    }
}

