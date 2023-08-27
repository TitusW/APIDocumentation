using System;
using APIService.Data;

namespace APIService.Repositories
{
	public interface IUnitOfWork
	{
        IAPIDefinitionRepo APIDefinitionRepo { get; }

        IAPIFieldRepo APIFieldRepo { get; }

        Task<bool> SaveAsync();
    }
}

