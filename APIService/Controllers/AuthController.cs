using System;
using APIService.Entities;
using APIService.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthUsecase _authUsecase;

        public AuthController(IAuthUsecase authUsecase)
        {
            this._authUsecase = authUsecase;
        }

        // POST api/values
        [HttpPost("login")]
        public async Task<ActionResult<string>> Post([FromBody]LoginRequest request)
        {
            var token = await _authUsecase.Login(request);
            return Ok(token);
        }
    }
}

