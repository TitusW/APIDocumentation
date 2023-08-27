
using System;
using APIService.Entities;
using APIService.Models;
using APIService.Repositories;

namespace APIService.Usecases
{
	public class UserUsecase : IUserUsecase
	{
		private readonly IUnitOfWork _unitOfWork;
		
		public UserUsecase(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task<User> Create(CreateUserRequest input)
		{
			var res = await this._unitOfWork.UserRepo.Create(input);
			await _unitOfWork.SaveAsync();

			return res;
		}
	}
}

