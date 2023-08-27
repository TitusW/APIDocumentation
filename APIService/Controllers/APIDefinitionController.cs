using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIService.Models;
using APIService.Data;
using APIService.Usecases;
using APIService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIDefinitionController : Controller
    {
        private readonly IAPIDefinitionUsecase _apiDefinitionUsecase;

        public APIDefinitionController(IAPIDefinitionUsecase apiDefinitionUsecase)
        {
            this._apiDefinitionUsecase = apiDefinitionUsecase;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<APIDefinition>> GetAll()
        {
            var res = await _apiDefinitionUsecase.GetAll();
            return res;
        }

        // GET api/values/5
        [HttpGet("{ksuid}")]
        public async Task<APIDefinition?> Get(string ksuid)
        {
            var res = await this._apiDefinitionUsecase.Get(ksuid);
            return res;
        }

        // POST api/values
        [HttpPost]
        public async Task<APIDefinition> Post([FromBody]CreateAPIDefinitionRequest input)
        {
            var res = await _apiDefinitionUsecase.Create(input);

            return res;
        }

        // PUT api/values/5
        [HttpPut("{ksuid}")]
        public async Task<APIDefinition> Put(string ksuid, [FromBody] UpdateAPIDefinitionRequest input)
        {
            var res = await _apiDefinitionUsecase.Update(ksuid, input);
            return res;
        }

        // DELETE api/values/5
        [HttpDelete("{ksuid}")]
        public async Task Delete(string ksuid)
        {
            await _apiDefinitionUsecase.Delete(ksuid);
            return;
        }
    }
}

