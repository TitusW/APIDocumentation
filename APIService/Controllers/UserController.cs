using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using APIService.Entities;
using APIService.Models;
using APIService.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserUsecase _userUsecase;

        public UserController(IUserUsecase userUsecase)
        {
            this._userUsecase = userUsecase;
        }

        [HttpGet, Authorize]
        public string Get()
        {
            return "You are authorized";
        }

        // POST api/values
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody]CreateUserRequest request)
        {
            var user = await this._userUsecase.Create(request);

            return Ok(user);
        }
    }
}

