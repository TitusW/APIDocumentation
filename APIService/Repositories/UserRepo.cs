using System;
using System.Security.Cryptography;
using APIService.Data;
using APIService.Entities;
using APIService.Models;
using Azure.Core;
using KSUID;
using Microsoft.EntityFrameworkCore;

namespace APIService.Repositories
{
	public class UserRepo : IUserRepo
	{
		public APIServiceContext _context { get; set; }

		public UserRepo(APIServiceContext context)
		{
			this._context = context;
		}

        public async Task<User> Create(CreateUserRequest input)
        {
            CreatePasswordHash(input.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User()
            {
                Username = input.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.Users.AddAsync(user);

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHah, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHah = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User?> Get(string ksuid)
        {
            return await _context.Users.FindAsync(ksuid);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.FromSql($"SELECT * FROM Users").ToListAsync();
        }

        public void Delete(string username)
        {
            User? current = _context.Users.Find(username);
            if (current == null)
            {
                throw new Exception("API Definition Not Found");
            }

            _context.Users.Remove(current);

            return;

        }
    }
}

