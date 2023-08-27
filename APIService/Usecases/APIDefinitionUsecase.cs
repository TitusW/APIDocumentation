using System;
using APIService.Entities;
using APIService.Models;
using APIService.Repositories;

namespace APIService.Usecases
{
	public class APIDefinitionUsecase : IAPIDefinitionUsecase
	{
		private readonly IUnitOfWork _unitOfWork;

        public APIDefinitionUsecase(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task<APIDefinition> Create(CreateAPIDefinitionRequest input)
		{
			var res = await _unitOfWork.APIDefinitionRepo.Create(input);
			res.APIFields = _unitOfWork.APIFieldRepo.BulkCreate(input.APIFields);
			await _unitOfWork.SaveAsync();

            return res;
		}

		public async Task Delete(string ksuid)
		{
			await _unitOfWork.APIDefinitionRepo.Delete(ksuid);
			await _unitOfWork.SaveAsync();
			return;
		}

        public async Task<APIDefinition?> Get(string ksuid)
		{
			var apiDefinition = await _unitOfWork.APIDefinitionRepo.Get(ksuid);
			return apiDefinition;
		}

        public async Task<IEnumerable<APIDefinition>> GetAll()
		{
			var res = await _unitOfWork.APIDefinitionRepo.GetAll();
			return res;
		}

		public async Task<APIDefinition> Update(string ksuid, UpdateAPIDefinitionRequest input)
		{
			var res = await _unitOfWork.APIDefinitionRepo.Update(ksuid, input);
            await _unitOfWork.SaveAsync();
            return res;
		}
        
    }
}

