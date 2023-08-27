using System;
using APIService.Entities;
using APIService.Models;

namespace APIService.Repositories
{
	public interface IUserRepo
	{
        Task<List<User>> GetAll();
        Task<User?> Get(string ksuid);
        Task<User> Create(CreateUserRequest input);
        void Delete(string ksuid);
    }
}

