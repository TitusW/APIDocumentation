using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Usecases
{
	public interface IAPIFieldUsecase
	{
        Task<IEnumerable<APIField>> GetAll(string? definitionKsuid);
        Task<APIField?> Get(string ksuid);
        Task<IEnumerable<APIField>> BulkCreate(List<CreateAPIFieldRequest> input);
        Task<APIField> Create(CreateAPIFieldRequest input);
        void Delete(string ksuid);
        Task<APIField> Update(string ksuid, UpdateAPIFieldRequest input);
    }
}

