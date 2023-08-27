using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Usecases
{
	public interface IAPIDefinitionUsecase
	{
        Task<APIDefinition> Create(CreateAPIDefinitionRequest input);
        Task Delete(string ksuid);
        Task<APIDefinition?> Get(string ksuid);
        Task<IEnumerable<APIDefinition>> GetAll();
        Task<APIDefinition> Update(string ksuid, UpdateAPIDefinitionRequest input);
    }
}

