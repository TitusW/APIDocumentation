using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Usecases
{
	public interface IUserUsecase
	{
        Task<User> Create(CreateUserRequest input);
    }
}

