using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIService.Entities;
using APIService.Models;
using APIService.Usecases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    public class APIFieldController : Controller
    {
        private readonly IAPIFieldUsecase _apiFieldUsecase;

        public APIFieldController(IAPIFieldUsecase apiFieldUsecase)
        {
            this._apiFieldUsecase = apiFieldUsecase;
        }

        // GET: api/values
        [HttpGet()]
        public async Task<IEnumerable<APIField>> GetAll([AsParameters] string definitionKsuid)
        {
            var res = await this._apiFieldUsecase.GetAll(definitionKsuid);
            return res;
        }

        // GET api/values/5
        [HttpGet("{ksuid}")]
        public async Task<APIField?> Get(string ksuid)
        {
            var res = await this._apiFieldUsecase.Get(ksuid);
            return res;
        }

        // POST api/values
        [HttpPost]
        public async Task<APIField> Post([FromBody]CreateAPIFieldRequest input)
        {
            var res = await this._apiFieldUsecase.Create(input);
            return res;
        }

        // PUT api/values/5
        [HttpPut("{ksuid}")]
        public async Task<APIField> Put(string ksuid, [FromBody]UpdateAPIFieldRequest input)
        {
            var res = await this._apiFieldUsecase.Update(ksuid, input);
            return res;
        }

        // DELETE api/values/5
        [HttpDelete("{ksuid}")]
        public void Delete(string ksuid)
        {
            _apiFieldUsecase.Delete(ksuid);
            return;
        }
    }
}

