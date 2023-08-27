using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using APIService.Entities;
using APIService.Models;
using APIService.Repositories;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIService.Usecases
{
	public class AuthUsecase : IAuthUsecase
	{
		private readonly IUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

		public AuthUsecase(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			this._unitOfWork = unitOfWork;
            this._configuration = configuration;
		}

		public async Task<string> Login(LoginRequest input)
		{
			var user = await _unitOfWork.UserRepo.Get(input.Username);
            if (user == null)
            {
                throw new Exception("Wrong username or password");
            }

            if (!VerifyPasswordHash(input.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Wrong username or password");
            }

            string token = CreateToken(user);

            return token;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

