using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Repositories
{
	public interface IAuthUsecase
	{
        Task<string> Login(LoginRequest input);
    }
}

