using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Repositories
{
	public interface IAPIDefinitionRepo
	{
        Task<List<APIDefinition>> GetAll();
        Task<APIDefinition?> Get(string ksuid);
        Task<APIDefinition> Create(CreateAPIDefinitionRequest input);
        Task Delete(string ksuid);
        Task<APIDefinition> Update(string ksuid, UpdateAPIDefinitionRequest input);
        Task<bool> SaveAsync();
    }
}

