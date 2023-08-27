using System;
using APIService.Entities;
using APIService.Models;
using APIService.Repositories;

namespace APIService.Usecases
{
	public class APIFieldUsecase : IAPIFieldUsecase
	{
		private readonly IUnitOfWork _unitOfWork;

		public APIFieldUsecase(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

        public async Task<IEnumerable<APIField>> BulkCreate(List<CreateAPIFieldRequest> input)
        {
            var res = _unitOfWork.APIFieldRepo.BulkCreate(input);
            await _unitOfWork.SaveAsync();

            return res;
        }

        public async Task<APIField> Create(CreateAPIFieldRequest input)
        {
            var res = await _unitOfWork.APIFieldRepo.Create(input);
            await _unitOfWork.SaveAsync();

            return res;
        }


        public void Delete(string ksuid)
        {
            _unitOfWork.APIFieldRepo.Delete(ksuid);
            _unitOfWork.SaveAsync();
            return;
        }

        public async Task<APIField?> Get(string ksuid)
        {
            var apiDefinition = await _unitOfWork.APIFieldRepo.Get(ksuid);
            return apiDefinition;
        }

        public async Task<IEnumerable<APIField>> GetAll(string? ksuid)
        {
            var res = await _unitOfWork.APIFieldRepo.GetAll(ksuid);
            return res;
        }

        public async Task<APIField> Update(string ksuid, UpdateAPIFieldRequest input)
        {
            var res = await _unitOfWork.APIFieldRepo.Update(ksuid, input);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

