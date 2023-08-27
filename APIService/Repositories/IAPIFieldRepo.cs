using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Repositories
{
	public interface IAPIFieldRepo
	{
        Task<List<APIField>> GetAll(string? definitionKsuid);
        Task<APIField?> Get(string ksuid);
        IEnumerable<APIField> BulkCreate(List<CreateAPIFieldRequest> input);
        Task<APIField> Create(CreateAPIFieldRequest input);
        void Delete(string ksuid);
        Task<APIField> Update(string ksuid, UpdateAPIFieldRequest input);
    }
}

